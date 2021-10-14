using CodyMazeBot.Commands;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;

namespace CodyMazeBot {
    public class Startup {
        public void ConfigureServices(IServiceCollection services) {
            services
                .AddControllers()
                .AddNewtonsoftJson()
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Latest);

            services.AddSingleton<Storage>();
            services.AddScoped<Conversation>();

            services
                .AddHttpClient("tgwebhook")
                .AddTypedClient<ITelegramBotClient>(
                httpClient => new TelegramBotClient(Environment.GetEnvironmentVariable("BOT_TOKEN"), httpClient)
            );

            services.AddAllScoped<ICommand>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(conf => {
                conf.MapControllers();
            });

            app.UseStaticFiles();
        }
    }
}
