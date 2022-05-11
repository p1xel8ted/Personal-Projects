using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web.DynamicData;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Microsoft.Win32;

namespace NewMedia
{
    public partial class _Default : Page
    {
        private readonly string[] _allowedExtensions = { ".mkv", ".mp4", ".avi" };
        private const string Movies = @"F:\Movies";
        private const string TV = @"F:\TV";
        private List<Media> _mediaList = new List<Media>();
        DataTable movieDataTable = new DataTable();
        DataTable tvDataTable = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
                _mediaList.Clear();
                movieDataTable.Clear();
                tvDataTable.Clear();
                GetMovies();
                GetEpisodes();
        }

        private void GetMovies()
        {
            var count = int.Parse(MovieResults.SelectedValue);

            
            movieDataTable.Columns.Add("Poster");
            movieDataTable.Columns.Add("Plot");
            movieDataTable.Columns.Add("Name");
            movieDataTable.Columns.Add("Rating");
            movieDataTable.Columns.Add("Runtime");
            movieDataTable.Columns.Add("Date Added");
      
            var files = Directory.GetFiles(Movies, "*.*", SearchOption.AllDirectories).Where(file => _allowedExtensions.Any(file.ToLower().EndsWith)).OrderByDescending(d => new FileInfo(d).CreationTime).ToList();
            
            files.RemoveRange(count, files.Count - count);
            foreach (var file in files)
            {
                var mediaFile = new Media(file);
                _mediaList.Add(mediaFile);
                var workRow = movieDataTable.NewRow();
                workRow["Poster"] = mediaFile.Poster;
                workRow["Plot"] = mediaFile.Plot;
                workRow["Name"] = mediaFile.Name;
                workRow["Rating"] = mediaFile.Rating;
                workRow["Runtime"] = mediaFile.Runtime;
                workRow["Date Added"] = mediaFile.Date;
                movieDataTable.Rows.Add(workRow);

            }

            MovieGrid.DataSource = movieDataTable;
            MovieGrid.DataBind();
        }

        private void GetEpisodes()
        {
            var count = int.Parse(TvResults.SelectedValue);

            tvDataTable.Columns.Add("Name");
            tvDataTable.Columns.Add("Date Added");

            var files = Directory.GetFiles(TV, "*.*", SearchOption.AllDirectories).Where(file => _allowedExtensions.Any(file.ToLower().EndsWith)).OrderByDescending(d => new FileInfo(d).CreationTime).ToList();
            files.RemoveRange(count, files.Count - count);
            foreach (var file in files)
            {
                var mediaFile = new Media(file);
                _mediaList.Add(mediaFile);
                var workRow = tvDataTable.NewRow();
                workRow["Name"] = mediaFile.Name;
                workRow["Date Added"] = mediaFile.Date;
                tvDataTable.Rows.Add(workRow);

            }

            TvGrid.DataSource = tvDataTable;
            TvGrid.DataBind();
        }

        private static string GetMimeType(string sExtension)
        {
            var extension = sExtension.ToLower();
            var key = Registry.ClassesRoot.OpenSubKey("MIME\\Database\\Content Type");

            foreach (var keyName in key.GetSubKeyNames())
            {
                var temp = key.OpenSubKey(keyName);
                if (extension.Equals(temp.GetValue("Extension")))
                {
                    return keyName;
                }
            }
            //no success
            return string.Empty;
        }

        private void DownloadFile(Media media)
        {

            try
            {

                var fileInfo = new FileInfo(media.Location);

                Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + media.Name + media.Type);
                Response.ContentType = GetMimeType(media.Type);
                Response.Flush();
                Response.TransmitFile(media.Location);
                Response.End();

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        protected void TvGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            var row = TvGrid.SelectedRow;
            var media = _mediaList.FirstOrDefault(m => m.Name == (string)tvDataTable.Rows[row.RowIndex]["Name"]);
            DownloadFile(media);
        }

        protected void MovieGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            var row = MovieGrid.SelectedRow;
            var media = _mediaList.FirstOrDefault(m => m.Name == (string)movieDataTable.Rows[row.RowIndex]["Name"]);
            DownloadFile(media);
        }
    }
}