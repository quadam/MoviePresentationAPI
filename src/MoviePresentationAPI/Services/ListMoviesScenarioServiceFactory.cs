using MoviePresentationAPI.Models;
using System;
using System.Collections.Generic;

namespace MoviePresentationAPI.Services
{
    public class ListMoviesScenarioServiceFactory : IListMoviesScenarioServiceFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Dictionary<MovieScenario, Type> _movieScenarioServices;

        public ListMoviesScenarioServiceFactory(IServiceProvider serviceProvider, Dictionary<MovieScenario, Type> movieScenarioServices)
        {
            _serviceProvider = serviceProvider;
            _movieScenarioServices = movieScenarioServices;
        }

        public IListMoviesScenarioService GetListMoviesService(MovieScenario scenario)
        {
            if (_movieScenarioServices.ContainsKey(scenario))
            {
                return (IListMoviesScenarioService)_serviceProvider.GetService(_movieScenarioServices[scenario]);
            }

            return null;
        }
    }
}
