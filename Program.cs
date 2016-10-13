using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using DbConnection;

namespace Quotes
{
    public class Program
    {
          public static void Create()
          {
            Console.WriteLine("Creating A New Quote");
            Console.Write("Your name: ");
            string user = Console.ReadLine();

            Console.Write("Your quote: ");
            string quote = Console.ReadLine();
            
            string query = $"INSERT INTO quotes (user, quote, created_at) VALUES('{user}', '{quote}', NOW())";
            DbConnector.ExecuteQuery(query);
            Console.WriteLine("The quote has been added to the db!");
          }

      
        public static void Main(string[] args)
        {  
            // Create();
            // Read();
            // Destroy();

            IWebHost host = new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();
            host.Run();
                
        }
    }
}
