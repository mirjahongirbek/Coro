using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Commutator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseUrls("http://*:2610").UseKestrel(m=> {
                m.AllowSynchronousIO = false;
            })
                .UseStartup<Startup>();
    }
}
