using System.Data.SqlClient;
using System.Reflection;
using Infastracture.RabbitMq;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjectTest.ApplicationService.TicketUser.Handlers;
using ProjectTest.ApplicationService.UserProfiles.Handlers;
using ProjectTest.CoreDomain.TicketUser.Data;
using ProjectTest.CoreDomain.UserProfile.Data;
using ProjectTest.EndPoint.Api.Models;
using ProjectTest.FrameWork.Data;
using ProjectTest.Infastracture.Query.Repository;
using ProjectTest.Infrastracture.Context;
using ProjectTest.Infrastracture.Repository;
using ProjectTest.Infrastracture.UserProfileUnitOfWork;
using ProjectTest.Rabbit.Bus;
using ProjectTest.Tools;

namespace ProjectTest.EndPoint.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _siteSetting = configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();

        }
        private readonly SiteSettings _siteSetting;
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMediatR(typeof(RegisterUserHandler).GetTypeInfo().Assembly);
            services.Configure<SiteSettings>(Configuration.GetSection(nameof(SiteSettings)));
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<IEventBus, RabbitMqBus>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<RegisterUserHandler>();
            services.AddScoped<CreateTicketHandler>();
           // services.AddScoped<IUserProfileQueryService,UserProfileQueryService>();
            services.AddScoped<ITicketQueryService, TicketQueryService>();
        
            //services.AddScoped(c => new SqlConnection(Configuration.GetConnectionString("TestProject")));
            services.AddDbContext<TestContext>(c => c.UseSqlServer(Configuration.GetConnectionString("TestProject")));
            
            
            services.AddSwagger();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
       
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseSwaggerAndUI();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
