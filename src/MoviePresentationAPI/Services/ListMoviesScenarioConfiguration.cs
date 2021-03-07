using Microsoft.Extensions.DependencyInjection;
using MoviePresentationAPI.Models;
using System;
using System.Collections.Generic;

namespace MoviePresentationAPI.Services
{
    public static class ListMoviesScenarioConfiguration
    {
        public static void AddListMoviesFactory(this IServiceCollection services)
        {
            Dictionary<MovieScenario, Type> movieScenarioServices = new Dictionary<MovieScenario, Type>
            {
                { MovieScenario.NowPlaying, typeof(ListMoviesNowPlayingService) },
                { MovieScenario.TopRated, typeof(ListMoviesTopRatedService) },
                { MovieScenario.Upcoming, typeof(ListMoviesUpcomingService) }
            };

            foreach (KeyValuePair<MovieScenario, Type> kvp in movieScenarioServices)
            {
                services.AddScoped(kvp.Value)
                    .AddScoped(s => (IListMoviesScenarioService)s.GetService(kvp.Value));
            }

            services.AddScoped<IListMoviesScenarioServiceFactory, ListMoviesScenarioServiceFactory>();

            services.AddSingleton(movieScenarioServices);
        }
    }
}
