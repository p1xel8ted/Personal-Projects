using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.UI;

namespace HulkMedia
{
    public partial class Default : Page
    {
        private readonly string[] _allowedExtensions = { ".mkv", ".mp4", ".avi" };
        private const string Movies = @"F:\Movies";
        private const string Tv = @"F:\TV";

        private const string Movies2 = @"G:\Movies";
        private const string Tv2 = @"G:\TV";

        private const string Movies3 = @"H:\Movies";
        private const string Tv3 = @"H:\TV";

        private readonly DataTable _movieDataTable = new DataTable();
        private readonly DataTable _tvDataTable = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            _movieDataTable.Clear();
                _tvDataTable.Clear();
                GetMovies();
                GetEpisodes();
            }

        private void GetMovies()
        {
            var count = int.Parse(MovieResults.SelectedValue);

            _movieDataTable.Columns.Add("Poster");
            _movieDataTable.Columns.Add("Plot");
            _movieDataTable.Columns.Add("Name");
            _movieDataTable.Columns.Add("Rating");
            _movieDataTable.Columns.Add("Runtime");
            _movieDataTable.Columns.Add("Date Added");
            _movieDataTable.Columns.Add("Location");

            var moviesOne = new List<string>(); //list for first movie directory
            var moviesTwo = new List<string>(); //list for second movie directory
            var moviesThree = new List<string>(); //list for third movie directory

            try
            {
                moviesOne = Directory.EnumerateFiles(Movies, "*.*", SearchOption.AllDirectories).Where(file => _allowedExtensions.Any(file.ToLower().EndsWith)).ToList();
            }
            catch
            {
                // ignored
            } //need this here to ignore the exception if the directory doesn't exist anymore
            try
            {
                moviesTwo = Directory.EnumerateFiles(Movies2, "*.*", SearchOption.AllDirectories).Where(file => _allowedExtensions.Any(file.ToLower().EndsWith)).ToList();
            }
            catch
            {
                // ignored
            } //need this here to ignore the exception if the directory doesn't exist anymore
            try
            {
                moviesThree = Directory.EnumerateFiles(Movies3, "*.*", SearchOption.AllDirectories).Where(file => _allowedExtensions.Any(file.ToLower().EndsWith)).ToList();
            }
            catch
            {
                // ignored
            } //need this here to ignore the exception if the directory doesn't exist anymore

            var moviesOneAndTwo = moviesOne.Concat(moviesTwo).ToList(); //add movies two to movies one
            var allMovies = moviesOneAndTwo.Concat(moviesThree).ToList(); //adds movies three to movies two and one

            var tempMovies = allMovies.Select(file => new KeyValuePair<string, DateTime>(file, new FileInfo(file).CreationTime)).ToList(); //creates a list with creation dates
            tempMovies.Sort((x, y) => (y.Value.CompareTo(x.Value))); //sorts that list by date
            tempMovies.RemoveRange(count, tempMovies.Count - count); //removes all the movies we don't need based on users selection (5, 10, 15 etc)

            var sortedMovies = tempMovies.Select(line => line.Key).ToList(); //converts the paired list back to a regular list

            foreach (var mediaFile in sortedMovies.Select(file => new Media(file, true)))
            {
                var workRow = _movieDataTable.NewRow();
                workRow["Poster"] = mediaFile.Poster;
                workRow["Plot"] = mediaFile.Plot;
                workRow["Name"] = mediaFile.Name;
                workRow["Rating"] = mediaFile.Rating;
                workRow["Runtime"] = mediaFile.Runtime;
                workRow["Date Added"] = mediaFile.Date;
                workRow["Location"] = mediaFile.Location;
                _movieDataTable.Rows.Add(workRow);
            }

            MovieGrid.DataSource = _movieDataTable;
            MovieGrid.DataBind();
        }

        private void GetEpisodes()
        {
            var count = int.Parse(TvResults.SelectedValue);

            _tvDataTable.Columns.Add("Poster");
            _tvDataTable.Columns.Add("Plot");
            _tvDataTable.Columns.Add("Name");
            _tvDataTable.Columns.Add("Rating");
            _tvDataTable.Columns.Add("Runtime");
            _tvDataTable.Columns.Add("Date Added");
            _tvDataTable.Columns.Add("Location");

            var tvOne = new List<string>(); //list for first tv directory
            var tvTwo = new List<string>(); //list for second tv directory
            var tvThree = new List<string>(); //list for third tv directory

            try
            {
                tvOne = Directory.EnumerateFiles(Tv, "*.*", SearchOption.AllDirectories).Where(file => _allowedExtensions.Any(file.ToLower().EndsWith)).ToList();
            }
            catch
            {
                // ignored
            } //need this here to ignore the exception if the directory doesn't exist anymore
            try
            {
                tvTwo = Directory.EnumerateFiles(Tv2, "*.*", SearchOption.AllDirectories).Where(file => _allowedExtensions.Any(file.ToLower().EndsWith)).ToList();
            }
            catch
            {
                // ignored
            } //need this here to ignore the exception if the directory doesn't exist anymore
            try
            {
                tvThree = Directory.EnumerateFiles(Tv3, "*.*", SearchOption.AllDirectories).Where(file => _allowedExtensions.Any(file.ToLower().EndsWith)).ToList();
            }
            catch
            {
                // ignored
            } //need this here to ignore the exception if the directory doesn't exist anymore


            var tvOneAndTwo = tvOne.Concat(tvTwo).ToList(); //add movies two to movies one
            var allTv = tvOneAndTwo.Concat(tvThree).ToList(); //adds movies three to movies two and one

            var tempTv = allTv.Select(file => new KeyValuePair<string, DateTime>(file, new FileInfo(file).CreationTime)).ToList(); //creates a list with creation dates
            tempTv.Sort((x, y) => (y.Value.CompareTo(x.Value))); //sorts that list by date
            tempTv.RemoveRange(count, tempTv.Count - count); //removes all the movies we don't need based on users selection (5, 10, 15 etc)

            var sortedTv = tempTv.Select(line => line.Key).ToList(); //converts the paired list back to a regular list

            foreach (var mediaFile in sortedTv.Select(file => new Media(file, false)))
            {
                var workRow = _tvDataTable.NewRow();
                workRow["Poster"] = mediaFile.Poster;
                workRow["Plot"] = mediaFile.Plot;
                workRow["Name"] = mediaFile.Name;
                workRow["Rating"] = mediaFile.Rating;
                workRow["Runtime"] = mediaFile.Runtime;
                workRow["Date Added"] = mediaFile.Date;
                workRow["Location"] = mediaFile.Location;
                _tvDataTable.Rows.Add(workRow);
            }

            TvGrid.DataSource = _tvDataTable;
            TvGrid.DataBind();
        }

    }
}