using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json;

namespace HulkMedia
{

    public class Media
    {
        private const string TheMovieDatabaseApiKey = "c0445cdd49529a7fdf3446cc44503370";
        public string Name { get; }
        public string Date { get; }
        public string Location { get; }
        public string Rating { get; }
        public string Runtime { get; }
        public string Plot { get; }
        public string Poster { get; }

        public Media(string location, bool movie)
        {
            var tempName = new FileInfo(location).Name;
            Name = tempName.Remove(tempName.Length - 4);
            Date = new FileInfo(location).CreationTime.ToShortDateString();
           //var year = Name.Substring(Name.Length - 5, 4);
            var splitName = Name.Split('(');
            var searchName = splitName[0];
            var year = splitName[1].Substring(0, 4);
            if (movie)
            {
                using var webClient = new WebClient();
                var moviedb = webClient.DownloadString("https://api.themoviedb.org/3/search/movie?api_key=" + TheMovieDatabaseApiKey + "&query=" + searchName + "&year=" + year);
                var a = JsonConvert.DeserializeObject<MediaSearch.RootObject>(moviedb);
                var result = a.results[0];
              //  var result2 = a.results.FirstOrDefault(b => b.title.)
                try
                {
                    var movieDetails = webClient.DownloadString("https://api.themoviedb.org/3/movie/" + result.id + "?api_key=" + TheMovieDatabaseApiKey);
                    var b = JsonConvert.DeserializeObject<MediaDetails.RootObject>(movieDetails);
                    Poster = "https://image.tmdb.org/t/p/w200/" + b.poster_path;
                    Plot = b.overview;
                    Rating = b.vote_average.ToString(CultureInfo.InvariantCulture) + "/10";
                    Runtime = b.runtime + "m";
                    Location = GetLocation(true, Path.GetPathRoot(new FileInfo(location).DirectoryName));
                }
                catch (Exception e)
                {
                    Rating = e.Message;
                }
            }
            else
            {
                var searchTerm = location.Split('\\');
                var showName = searchTerm[2].Trim(); //store show name i.e. The Good Doctor
                if (showName.EndsWith(")"))
                {

                    var tshowName = showName.Split('('); //removes year from any shows
                    showName = tshowName[0].Trim();
                }
                var temp = Name.Replace(showName, ""); //removing show name from the path leaving " - 3x09 - EpisodeTitle"
                var splitTemp = temp.Split('-'); //splitting by
                var split = splitTemp[1].Split('x'); //splitting by x so we can have season and episode number
                var season = split[0].Trim(); //store season number
                var episode = split[1].Trim(); //store episode number

                using var webClient = new WebClient();

                var tvdb = webClient.DownloadString("https://api.themoviedb.org/3/search/tv?api_key=" + TheMovieDatabaseApiKey + "&query=" + showName);
                var a = JsonConvert.DeserializeObject<TvMediaSearch.RootObject>(tvdb);
                var searchResult = a.results.First(result => searchName.Contains(result.name.Replace(":", "")));
                try
                {
                    var tvDetails = webClient.DownloadString("https://api.themoviedb.org/3/tv/" + searchResult.id + "?api_key=" + TheMovieDatabaseApiKey);
                    var b = JsonConvert.DeserializeObject<TvMediaDetails.RootObject>(tvDetails);
                    Name = $"{showName}<br/> Season {season}, Episode {episode}";
                    Poster = "https://image.tmdb.org/t/p/w200/" + b.poster_path;
                    Plot = b.overview;
                    Runtime = b.episode_run_time[a.results.IndexOf(searchResult)].ToString() + "m";
                    Rating = b.vote_average.ToString(CultureInfo.InvariantCulture) + "/10";
                    Location = GetLocation(false, Path.GetPathRoot(new FileInfo(location).DirectoryName));
                }
                catch (Exception e)
                {
                    Rating = e.Message;
                }
            }
        }

        public string GetLocation(bool movie, string location)
        {
            if (movie)
            {
                if (location.Contains("F"))
                {
                    return "Movies (F)";
                }
                if (location.Contains("G"))
                {
                    return "Movies (G)";
                }
                if (location.Contains("H"))
                {
                    return "Movies (H)";
                }
            }
            else
            {
                if (location.Contains("F"))
                {
                    return "TV (F)";
                }
                if (location.Contains("G"))
                {
                    return "TV G)";
                }
                if (location.Contains("H"))
                {
                    return "TV (H)";
                }
            }
            return null;
        }
    }
}