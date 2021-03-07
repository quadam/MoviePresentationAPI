

# Movie Presentation API

## Running

Use your TheMovieDatabase API Key from [The Movie Database](https://www.themoviedb.org/).

The API key should be set in the environment variable `MP_API_KEY`.

The API starts running by hitting ctrl+f5 in Visual Studio with the .sln file opened.
A Swagger UI will open in the browser where the API can be tested from.

## Architecture

The API is built with ASP.NET 5, using ASP.NET Core Web API. It has a single controller
with a single method, the end point is

    /movies?page=0&Scenario=TopRated

Where Scenario fetches from the desired list on The Movie Database.

Each call uses a `MovieInquiryProcessor`. The algorithm is basically to fetch a service
implementation based on the scenario, call the list movies function and return the
result in models that are specific to our API. The dependency of `TMDbLib` is
abstracted in the `MoviePresentationAPI.Data.Tmdb` project.

The solution uses dependency injection with .NET Core's built-in service provider.
Every relevant method is async for better performance. For unit tests, `Moq` is
used for mocking.

