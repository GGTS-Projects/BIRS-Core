using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;

using Akka.Actor;



using JetBrains.Annotations;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Api.Classes.Eventing;
using Api.Classes.IO;

namespace Api
{
    [UsedImplicitly]
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [UsedImplicitly]
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddControllers();
        //}
        // This method gets called by the runtime. Use this method to add services to the container.
      [UsedImplicitly]
        public void ConfigureServices(IServiceCollection services)
        {
            string appConfig = File.ReadAllText("app.config");
            var system = ActorSystem.Create("reservieren", appConfig);

            var eventConnectionHolder = system.ActorOf(ConnectionHolder.props(), "event-connection-holder");
            var persistence = system.ActorOf(Persistence.props(eventConnectionHolder), "persistence");

            services.AddTransient(typeof(IEventConnectionHolderActorRef),
                                  pServiceProvider => new EventConnectionHolderActorRef(eventConnectionHolder));
            services.AddTransient(typeof(IPersistenceActorRef),
                                  pServiceProvider => new PersistenceActorRef(persistence));
            services.AddMvc();
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [UsedImplicitly]
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           // app.UseMvc();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
