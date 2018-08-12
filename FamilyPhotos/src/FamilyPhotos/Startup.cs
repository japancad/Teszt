using System;
using System.Collections.Generic;
using System.Linq; 
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using FamilyPhotos.Repository;
using FamilyPhotos.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace FamilyPhotos
{
    public class Startup
    {
        // konfigurácios beállitások
        private readonly IConfigurationRoot Configuration;

        //átveszük a paraméterként a környezetet
        public Startup(IHostingEnvironment environment)
        {
            //var builder = new ConfigurationBuilder()
            //    .SetBasePath(environment.ContentRootPath) // <== compile failing here
            //    .AddJsonFile("appsettings.json",optional: true, reloadOnChange:true)  //közös paraméterek
            //    .AddJsonFile($"appsettings{environment.EnvironmentName}.json", optional: true)  //itt tudunk Development/Produktion/Stating paraméterlista
            //    .AddEnvironmentVariables()   //környezeti paraméterek
            //    ;

            //Configuration = builder.Build();

            //var builder = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory()) // <== compile failing here
            //    .AddJsonFile("appsettings.json");

            //Microsoft.Extensions.Configuration = builder.Build();

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FamilyPhotosContext>(options =>
            {
                options.UseSqlServer(connectionString: "Server=.\\sqlexpress;Database=FamilyPhotoDB;Trusted_Connection=True;");
            });

            //throw new Exception("Ez itt egy hiba");

            //services.AddSingleton<IPhotoRepository ,PhotoTestDataRepository>();
            services.AddSingleton<IPhotoRepository, PhotoEfCoreDataRepository>();

            var autoMApperCfg = new AutoMapper.MapperConfiguration(cfg => cfg.AddProfile(new ViewModel.PhotoProfile()));
            var mapper = autoMApperCfg.CreateMapper();
            services.AddSingleton(mapper);  //innentol kérhetem a Controller papaméterlistájában

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            

            //app.UseStatusCodePages();
            //app.UseStatusCodePages("text/plain", "Ez egy hibás kérés, a kód:  {0}");
            //app.UseStatusCodePages(async context =>
            //{
            //    context.HttpContext.Response.ContentType = "text/plain";
            //    await context.HttpContext.Response.WriteAsync($"Ez itt a statusCodePage delegate setting, a kód pedig : {context.HttpContext.Response.StatusCode}");
            //});

            //app.UseStatusCodePagesWithRedirects("~/Errors/StatusCodePagesWithRedirects/{0}");

            //app.UseStatusCodePagesWithRedirects("~/Errors/StatusCodePagesWithRedirects?statusCode={0}");

            app.UseStatusCodePagesWithReExecute("/Errors/StatusCodePagesWithReExecute", "?statusCode={0}");

            //app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();
        }
    }
}
