using System;
using Microsoft.MobileBlazorBindings;
using Microsoft.Extensions.Hosting;
using Xamarin.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorXamarin
{
    public class App : Application
    {
        public IHost AppHost{get; }
        public App(IServiceCollection additionalServices)
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    // Register app-specific services
                    if (additionalServices != null)
                    {
                        services.AddAdditionalServices(additionalServices);
                    }
                    //Register app-specific services
                    services.AddSingleton<AppState>();
                })
                .Build();

            AppHost.AddComponent<ToDoApp>(parent: this);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
