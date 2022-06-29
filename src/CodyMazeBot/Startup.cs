using CodyMazeBot.Commands;
using CodyMazeBot.Game;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Telegram.Bot;

namespace CodyMazeBot {
    public class Startup {

        private static Dictionary<BotState, Type> _stateProcessors = new Dictionary<BotState, Type>();
        public static IReadOnlyDictionary<BotState, Type> StateProcessors {
            get {
                return new ReadOnlyDictionary<BotState, Type>(_stateProcessors);
            }
        }

        public void ConfigureServices(IServiceCollection services) {
            services
                .Configure<RequestLocalizationOptions>(config => {
                    config.DefaultRequestCulture = new RequestCulture("it");
                    config.AddSupportedCultures("en", "it");
                    config.AddSupportedUICultures("en", "it");
                })
                .AddControllers()
                .AddNewtonsoftJson()
            ;

            services.AddSingleton<Storage>();
            services.AddScoped<Conversation>();

            services
                .AddHttpClient("tgwebhook")
                .AddTypedClient<ITelegramBotClient>(
                    httpClient => new TelegramBotClient(Environment.GetEnvironmentVariable("BOT_TOKEN"), httpClient)
                )
            ;

            services.AddAllScoped<ICommand>();
            services.AddAllScoped<BaseStateProcessor>(type => {
                var attrs = type.GetCustomAttributes(typeof(StateHandlerAttribute), false);
                foreach(StateHandlerAttribute attr in attrs) {
                    _stateProcessors.Add(attr.State, type);
                }
            });
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
            app.UseRequestLocalization();
        }

    }
}
