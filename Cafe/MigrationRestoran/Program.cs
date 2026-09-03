using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace MigrationRestoran
{
    class Program
    {
        public static IConfigurationRoot Configuration { get; set; }
        static void Main(string[] args)
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
                builder.AddUserSecrets<Program>();
            }

            Configuration = builder.Build();
            Waiters[] waiters;
            Sources[] sources;
            Items[] items;
            Abonent[] abonents;
            Order[] order;
            Details[] details;
            using (var oldContext = new RestorantContextOld())
            {
                waiters = oldContext.Waiters.ToArray();
                sources = oldContext.Sources.ToArray();
                items = oldContext.Items.ToArray();
                abonents = oldContext.Abonent.ToArray();
                order = oldContext.Order.Include("Details").ToArray();
            }

            using (var context = new RestorantContext())
            {
                //context.Waiters.AddRange(waiters);
                context.Sources.AddRange(sources);
                context.Items.AddRange(items);
                context.Abonent.AddRange(abonents);
                context.Order.AddRange(order);
                context.SaveChanges(); 
            }




        }
    }
}
