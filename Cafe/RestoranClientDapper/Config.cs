using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestoranClient.Data;
using RestoranClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestoranClient
{
    public static class Config
    {
        public static string ConnectionString = "Data Source=192.168.10.20;Initial Catalog=RestorantNew;Persist Security Info=True;User ID=sa;Password=Aa12345678";
        public static IConfigurationRoot Configuration { get; set; }
        public static Abonent[] Abonents { get; set; }
        //public static SourceItem[] SourceItems { get; set; }
        public static FoodItem[] FoodItems { get; set; }


        public static void Refresh()
        {
            using (var context = new RestoranDbContext())
            {
                Abonents = context.Abonent.ToArray();
                //SourceItems = context.Sources.ToArray();
                FoodItems = context.FoodItems.ToArray();
            }
        }


       static Config()
        {
            var devEnvironmentVariable = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");

            var isDevelopment = string.IsNullOrEmpty(devEnvironmentVariable) ||
                                devEnvironmentVariable.ToLower() == "development";
            //Determines the working environment as IHostingEnvironment is unavailable in a console app

            var builder = new ConfigurationBuilder();
            // tell the builder to look for the appsettings.json file
            builder
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            //only add secrets in development
            if (isDevelopment)
            {
                builder.AddUserSecrets<App>();
            }

            Configuration = builder.Build();

            // load default collections
            Refresh();
        }


        public static int WaiterId { get; set; }
        public static string WaiterName { get; set; }
    }
}
