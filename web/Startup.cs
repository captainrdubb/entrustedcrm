using Entrusted.Web.Data;
using Entrusted.Web.Data.Models.Read;
using Entrusted.Web.Data.Models.Write;
using Entrusted.Web.Data.Repositories.Read;
using Entrusted.Web.Data.Repositories.Write;
using Entrusted.Web.Data.Search;
using Entrusted.Web.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using StackExchange.Redis;

namespace Entrusted.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            MongoDefaults.GuidRepresentation = MongoDB.Bson.GuidRepresentation.Standard;

            services.AddSingleton<DbConnectionFactory>(new DbConnectionFactory("mongodb://localhost:27017"));

            services.AddTransient<IWriteRepository<CustomerWrite>>(provider =>
            {
                var factory = provider.GetRequiredService<DbConnectionFactory>();
                return new CustomerWriteRepository(factory.MongoClient.GetDatabase("Entrusted"));
            });

            services.AddTransient<IWriteRepository<NoteWrite>>(provider =>
            {
                var factory = provider.GetRequiredService<DbConnectionFactory>();
                return new NotesWriteRepository(factory.MongoClient.GetDatabase("Entrusted"));
            });

            services.AddTransient<IReadRepository<CustomerRead>>(provider =>
            {
                var factory = provider.GetRequiredService<DbConnectionFactory>();
                return new CustomersReadRepository(factory.MongoClient.GetDatabase("Entrusted"));
            });

            services.AddTransient<IReadRepository<NoteRead>>(provider =>
            {
                var factory = provider.GetRequiredService<DbConnectionFactory>();
                return new NotesReadRepository(factory.MongoClient.GetDatabase("Entrusted"));
            });

            services.AddTransient<ISearchStringParser<CustomerRead>, CustomerSearchStringParser>();

            services.AddSignalR();

            services.AddSingleton<IUserIdProvider, DefaultUserIdProvider>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });

            app.UseSignalR(route =>
            {
                route.MapHub<AdminHub>("/adminhub");
            });
        }
    }
}
