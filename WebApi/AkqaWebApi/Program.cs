using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace AkqaWebApi
{
    public class Program
    {
        public static void Main(string[] args) => new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseApplicationInsights().UseUrls("http://0.0.0.0:5050")
                .Build().Run();
        
      
    }
}
