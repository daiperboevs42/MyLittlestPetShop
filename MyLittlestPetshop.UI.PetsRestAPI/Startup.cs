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
using MyLittlestPetShop.Core.AppService;
using MyLittlestPetShop.Core.AppService.Service;
using MyLittlestPetShop.Core.DataService;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MyLittlestPetshop.UI.PetsRestAPI.Helper;
using MyLittlestPetshop.Infrastructure.SQL.Data.Repositories;
using MyLittlestPetshop.Infrastructure.SQL.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using MyLittlestPetShop.Core.Entity;

namespace MyLittlestPetshop.UI.PetsRestAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //JwsSecurityKey.SetSecret("daiBepeux77");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = JwsSecurityKey.Key,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(5)
                };
            });

            //services.AddDbContext<PetshopAppContext>(/*opt => opt.UseInMemoryDatabase("ThaDB")*/);
            services.AddDbContext<PetshopAppContext>(opt => opt.UseSqlite("Data Source=petshopApp.db"));

            services.AddScoped<IPetRepo, PetRepository>();
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IPetTypeService, PetTypeService>();
            services.AddScoped<IUserRepo, UserRepository>();
            services.AddScoped<IPetTypeRepo, PetTypeRepository>();
            services.AddScoped<IOwnerRepo, OwnerRepository>();
            services.AddScoped<IOwnerService, OwnerService>();
            services.AddControllers().AddNewtonsoftJson(options =>
            {    // Use the default property (Pascal) casing
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.MaxDepth = 2;  // 100 pet limit per owner
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<PetshopAppContext>();
                    DBInitializer.SeedDB(ctx);
                }
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
