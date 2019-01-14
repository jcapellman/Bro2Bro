using System.IO;

using Microsoft.AspNetCore.Hosting;

using NLog.Web;

namespace Bro2Bro.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseNLog()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}