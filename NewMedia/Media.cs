using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace NewMedia
{
    
    public class Media
    {
        private const string ApiKey = "5e9ea432";

        public string Name { get; }
        public string Date { get; }
        public string Location { get; }
        public string Rating { get; }
        public string Runtime { get; }
        public string Plot { get; }
        public string Poster { get; }
        public string Type { get; }

        public Media(string location)
        {
            var tempName = new FileInfo(location).Name;
            Name = tempName.Remove(tempName.Length - 4);
            Date = new FileInfo(location).CreationTime.ToShortDateString();
            Location = location;
            var year = Name.Substring(Name.Length - 5, 4);
            var searchName = Name.Remove(Name.Length - 7);
            Type = new FileInfo(location).Extension;

            var webClient = new WebClient();
            var json = webClient.DownloadString("http://www.omdbapi.com/?t=" + searchName + "&y=" + year + "&r=json&apikey=" + ApiKey);

            var m = JsonConvert.DeserializeObject<RootObject>(json);
            if (m.Response == "True")
            {
                Poster = m.Poster;
                Plot = m.Plot;
                Rating = m.imdbRating + "/10";
                Runtime = m.Runtime;
            }
            else
            {
                Poster = m.Poster;
                Plot = string.Empty;
                Rating = string.Empty;
                Runtime = string.Empty;
            }

        }

    }
}