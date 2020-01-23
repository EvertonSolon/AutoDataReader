using System;
using System.IO;

namespace AutoDataReader.Helpers
{
    public static class DbPathFile
    {
        public static string GetLocation()
        {
            #region Another way to get file location
            //var location = Assembly.GetEntryAssembly().Location;
            //var dbFileLocation = "Context\\DataBase.db";
            //while (location.Contains("bin"))
            //{
            //    location = Path.GetDirectoryName(location);
            //}
            #endregion

            var dbFileLocation = new BuilderHelper()._configuration["DbSettings:MySql:DbFileLocation"];
            var location = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));
            var dbPathFile = Path.Combine(location, dbFileLocation);

            return dbPathFile;
        }
    }
}
