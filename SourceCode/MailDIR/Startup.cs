﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MailDIR.Repository;
using MailDIR.Services.contract;
using MailDIR.Services.implementation;

namespace MailDIR.App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            string conStr = this.Configuration.GetConnectionString("MyConn");            
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(conStr));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUsersRepo, UsersRepo>();
            services.AddScoped<IMailDetailsColMapRepo, MailDetailsColMapRepo>();
            services.AddScoped<IMailDetailRepo, MailDetailRepo>();
            services.AddScoped<IMailItemRepo, MailItemRepo>();
            services.AddScoped<IImportToSQLRepo, ImportToSQLRepo>();
            services.AddScoped<IMailDetailsViewModelRepo, MailDetailsViewModelRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Users}/{id?}");
            });
        }
    }
}