using devboost.Domain.Handles.Commands;
using devboost.Domain.Handles.Commands.Interfaces;
using devboost.Domain.Handles.Queries;
using devboost.Domain.Handles.Queries.Interfaces;
using devboost.Domain.Repository;
using devboost.dronedelivery.Config;
using devboost.Repository;
using devboost.Repository.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace devboost.dronedelivery
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
            services.AddCors();
            services.AddControllers();

            //Registra Authentication por JWT
            services.AddJwtconfiguration(Configuration);

            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IDroneRepository, DroneRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();

            services.AddScoped<ITokenHandler, TokenHandler>();
            services.AddScoped<ILoginHandler, LoginHandler>();
            services.AddScoped<IUserHandler, UserHandler>();

            services.AddScoped<IPedidoHandler, PedidoHandler>();
            services.AddScoped<IDroneHandler, DroneHandler>();

            services.AddScoped<IClienteQueryHandler, ClienteQueryHandler>();


            // Evita o Loop Referência na serialização do JSON
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
