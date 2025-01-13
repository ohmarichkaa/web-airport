using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirportProj.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using Microsoft.Extensions.Hosting;

namespace AirportProj
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IRepository, MyRepository>();
            string ConnectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AerportContext>(options => options.UseSqlServer(ConnectionString));
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
            });
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, AerportContext ctx)
        {
            //ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                    pattern: "{controller=Home}/{action=HomePage}/{id?}");

            });
        }
    }
}
