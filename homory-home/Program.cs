using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace homory.home
{
    public class Program
    {
        public static void Main(string[] arguments) => Host.CreateDefaultBuilder(arguments).ConfigureWebHostDefaults(builder => { builder.UseStartup<Startup>(); }).Build().Run();
    }
}
