using System.Text;
using PQ_API.Classes;
using PQ_API.HealthChecks;
using PQ_API.Helpers;
using PQ_API.Interfaces;
using PQ_API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace PQ_API
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
            services.AddControllers();
            services.AddHttpContextAccessor();
            services.AddMvc().AddNewtonsoftJson();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IDealService, DealService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<ISubmitDealService, SubmitDealService>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo    
                    {
                        Title = "PQ_API",
                        Description = "PQ_API",
                        Version = "v1"
                    });
            });

            
            
            // configure strongly typed settings object for Authentication
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            AppSettings appSettings = Configuration.GetSection(nameof(AppSettings)).Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            // Configure JWT Authentication
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            

            // Configure RUBI DB Settings
            RubiDBSettings rubiDbSettings = Configuration.GetSection(nameof(RubiDBSettings)).Get<RubiDBSettings>();
            services.AddSingleton<RubiDBSettings>(rubiDbSettings);

            // Register Heatlh Checks
            services.AddHealthChecks().AddCheck("DB Health Check", () => DBHealthCheckProvider.Check(rubiDbSettings.ConnectionString));               
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PQ_API v1"));
            }

            app.UseRouting();
            
            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health");
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "PQ_API");
                options.RoutePrefix = "";
            });
        }
    }
}
