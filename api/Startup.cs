using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using weatherer.Interfaces;
using weatherer.Libraries.OpenWeather;
using weatherer.Services;

namespace weatherer
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
            services.AddCors(options =>
            {
                options.AddPolicy(name: "DeveloperOrigins",
                                  builder =>
                                  {
                                      builder.WithOrigins("*");
                                  });
            });
            services.AddControllers();
            services.AddHttpClient();

            // Add OpenWeather
            services.Configure<OpenWeatherSettings>(Configuration.GetSection("OpenWeather"));
            services.AddHttpClient<IOpenWeatherClient, OpenWeatherClient>();


            services.AddSingleton<IForecastRetrievable, OpenWeatherForecastRetriever>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors("DeveloperOrigins");
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
