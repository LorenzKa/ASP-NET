using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicManagerDb;

namespace MusicManager
{
    public class Startup
    {
        internal void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddDbContext<MusikManager>(x => x.UseSqlServer(@"Server=(LocalDB)\mssqllocaldb;attachdbfilename=C:\Users\loren\source\repos\LorenzKa\ASP.NET\CSharp\MusicManager\MusicManager\Musik.mdf;integrated security=True"));
            services.AddSingleton<MainWindow>();
            services.AddHostedService<Seeder>();
        }
        
    }
}
