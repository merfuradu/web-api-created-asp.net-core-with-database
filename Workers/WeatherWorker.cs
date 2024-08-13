using System.Net.Http;
using Newtonsoft.Json;
using WebAPI_week1.Models;
using AutoMapper;
using WebAPI_week1.DTOs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_week1.WeatherWorkers
{
    public class WeatherWorker : BackgroundService
    {
        private readonly ILogger<WeatherWorker> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IMapper _mapper;

        public WeatherWorker(
            ILogger<WeatherWorker> logger,
            IHttpClientFactory httpClientFactory,
            IServiceScopeFactory serviceScopeFactory,
            IMapper mapper)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _serviceScopeFactory = serviceScopeFactory;
            _mapper = mapper;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                _logger.LogInformation("WeatherWorker running at: {time}", DateTimeOffset.Now);

                await FetchAndSaveWeatherDataAsync();

                await Task.Delay(1000000, cancellationToken); // Delay for 1000 seconds
            }
        }

        private async Task FetchAndSaveWeatherDataAsync()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<PersonsDB>();
            var httpClient = _httpClientFactory.CreateClient();

            //deleting the old data
            context.DataPoints.RemoveRange(context.DataPoints);
            context.Weathers.RemoveRange(context.Weathers);
            await context.SaveChangesAsync();

         


            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://weatherbit-v1-mashape.p.rapidapi.com/current?lon=44.42&lat=26&units=imperial&lang=en"),
                Headers =
                {
                    { "x-rapidapi-key", "e7f54b7c50msh25752da413ad811p14d90fjsnf7d56c6b4027" },
                    { "x-rapidapi-host", "weatherbit-v1-mashape.p.rapidapi.com" },
                },
            };

            using (var response = await httpClient.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var weatherDto = JsonConvert.DeserializeObject<WeatherDTO>(responseBody);

                    if (weatherDto != null)
                    {
                        // Map DTO to Entity
                        var weatherEntity = _mapper.Map<Weather>(weatherDto);

                        // Save to database
                        context.Weathers.Add(weatherEntity);
                        //await context.SaveChangesAsync();
                        


                        foreach (var datumDto in weatherDto.data)
                        {
                            var datumEntity = _mapper.Map<Datum>(datumDto);
                            datumEntity.WeatherId = weatherEntity.Id; // Ensure proper foreign key assignment
                            context.DataPoints.Add(datumEntity);
                        }

                        await context.SaveChangesAsync(); // Save all the data points to the data
                    }
                }//end of response.isSuccesfull if
                else
                {
                    _logger.LogError("Failed to fetch weather data. Status Code: {statusCode}", response.StatusCode);
                }
            }
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("WeatherWorker is stopping.");
            await base.StopAsync(cancellationToken);
        }
    }
}
