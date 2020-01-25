//using Msi.Extensions.Persistence;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.IO;
//using static Core.Common.Extensions.ConfigurationExtensions;

namespace Comment.Tools
{

    class Program
    {
        static void Main(string[] args)
        {

            //var hello = new HelloWorld.HelloWorld().Hello();

            ////Console.WriteLine("ddd");
            //var configuration = BuildConfiguration(new ConfigParams
            //{
            //    BasePath = Directory.GetCurrentDirectory()
            //});

            //// Migrations
            //Console.Write("\nDo you want to run Migrations? (y/n). ");
            //var mYes = Console.ReadLine()?.ToLower();
            //if (!string.IsNullOrEmpty(mYes) && mYes.Equals("y"))
            //{

            //    string commentConnectionString = configuration.GetSection($"{nameof(CommentDatabaseOptions)}:{nameof(CommentDatabaseOptions.ConnectionString)}").Value;
            //    var commentDataContext = new DataContextFactory<CommentDataContext>().Create(commentConnectionString);

            //    commentDataContext.Database.Migrate();
            //}
        }

    }
}
