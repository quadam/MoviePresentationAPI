using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MoviePresentationAPI.Data.Tmdb;
using MoviePresentationAPI.InquiryProcessing;
using MoviePresentationAPI.Services;
using System;
using System.Text.Json.Serialization;
using TMDbLib.Client;

namespace MoviePresentationAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var apiKey = Configuration.GetValue<string>("MP_API_KEY");

            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new Exception("Configure the API Key with environment variable MP_API_KEY");
            }

            services.AddScoped(_ => new TMDbClient(apiKey));
            services.AddScoped<ITheMovieDatabaseClient, TheMovieDatabaseClient>();

            services.AddAutoMapper(typeof(Startup), typeof(TmdbMovieTranslatorProfile));

            services.AddScoped<IMoviesInquiryProcessor, MoviesInquiryProcessor>();

            services.AddListMoviesFactory();

            services.AddControllers()
                .AddJsonOptions(options =>
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MoviePresentationAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MoviePresentationAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
