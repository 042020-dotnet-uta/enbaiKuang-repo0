using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace RPS_Game
{
    class Program{
        static void Main(string[] args){
            var services = new ServiceCollection();
            ConfigureServices(services);

            using (ServiceProvider serviceProvider = services.BuildServiceProvider()) {
                    Game rps = serviceProvider.GetService<Game>(); // creates new Game
                    rps.playGame(); // calls playGame method in Game class to start game
            }
         }

        private static void ConfigureServices(ServiceCollection services) {
            services.AddLogging(configure => configure.AddConsole())
                .AddTransient<Game>();
        }
     }
 }