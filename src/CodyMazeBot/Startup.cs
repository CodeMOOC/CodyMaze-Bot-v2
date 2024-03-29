using CodyMazeBot.Commands;
using CodyMazeBot.Game;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Telegram.Bot;

namespace CodyMazeBot {
    public class Startup {

        private readonly IConfiguration _config;

        public Startup(IConfiguration configuration) {
            _config = configuration;
        }

        private static readonly Dictionary<BotState, Type> _stateProcessors = new();
        public static IReadOnlyDictionary<BotState, Type> StateProcessors {
            get {
                return new ReadOnlyDictionary<BotState, Type>(_stateProcessors);
            }
        }

        public void ConfigureServices(IServiceCollection services) {
            var confBot = _config.GetRequiredSection("Bot");
            var botApiToken = confBot["ApiToken"];
            if(string.IsNullOrEmpty(botApiToken)) {
                throw new ArgumentException("Configuration element Bot:ApiToken not set");
            }

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
            services.AddSingleton<MazeGenerator>();

            services
                .AddHttpClient("tgwebhook")
                .AddTypedClient<ITelegramBotClient>(
                    httpClient => new TelegramBotClient(botApiToken, httpClient)
                )
            ;

            services.AddAllScoped<ICommand>();
            services.AddAllScoped<BaseStateProcessor>(type => {
                var attrs = type.GetCustomAttributes(typeof(StateHandlerAttribute), false);
                foreach (StateHandlerAttribute attr in attrs) {
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
