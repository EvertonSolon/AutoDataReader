using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AutoDataReader.Helpers
{
    public class BuilderHelper
    {
        public IConfiguration _configuration;

        public BuilderHelper()
        {

            //var dbFileLocation = "Context\\DataBase.db";
            var location = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));
            //var dbPathFile = Path.Combine(location, dbFileLocation);

            var builder = new ConfigurationBuilder()
                            .SetBasePath(location)
                            .AddJsonFile("appsettings.json");

            _configuration = builder.Build();
        }


    }
}
