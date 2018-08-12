using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace FamilyPhotos
{
    /// <summary>
    /// 
    /// </summary>
    public class Program
    {
    
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseUrls("https://*:1000")
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .CaptureStartupErrors(true)
                .UseSetting("detailedErrors","true")
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
