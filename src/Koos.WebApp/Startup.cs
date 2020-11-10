using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Blazor.IndexedDB.Framework;
using Microsoft.AspNetCore.Components.Authorization;

namespace Koos.WebApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddBlazoredLocalStorage();
            services.AddSingleton(typeof(Koos.Application.Services.GoalServices));
            services.AddSingleton<IIndexedDbFactory, IndexedDbFactory>();

            services.AddAuthorizationCore();
            services.AddScoped<AuthenticationStateProvider, KoosAuthStateProvider>();

            // services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //     .AddJwtBearer(options =>
            //     {
            //         options.TokenValidationParameters = new TokenValidationParameters
            //         {
            //             ValidateIssuer = true,
            //             ValidateAudience = true,
            //             ValidateLifetime = true,
            //             ValidateIssuerSigningKey = true,
            //             ValidIssuer = Configuration["AppSettings:JwtIssuer"],
            //             ValidAudience = Configuration["AppSettings:JwtAudience"],
            //             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["AppSettings:JwtSecurityKey"]))
            //         };
            //     });
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
