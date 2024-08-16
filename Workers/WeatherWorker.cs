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

                try
                {
                    await FetchAndSaveWeatherDataAsync();
                    _logger.LogInformation("Weather data fetched and saved succesfully at {time}.", DateTimeOffset.Now);
                }
                catch (Exception ex) 
                {
                    _logger.LogError(ex, "An error occured while fetching and saving weather data at {time}.", DateTimeOffset.Now);
                }
                await Task.Delay(1500000, cancellationToken); // Delay for 1500 seconds
            }
        }

        private async Task FetchAndSaveWeatherDataAsync()
        {
            _logger.LogInformation("Starting data fetch and save operation...");

            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<PersonsDB>();
            var httpClient = _httpClientFactory.CreateClient();

            //deleting the old data
            _logger.LogInformation("Deleting old weather data...");

            context.DataPoints.RemoveRange(context.DataPoints);
            context.Weathers.RemoveRange(context.Weathers);
            await context.SaveChangesAsync();

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://weatherbit-v1-mashape.p.rapidapi.com/forecast/3hourly?lat=44.42&lon=26&units=metric&lang=en"),
                Headers =
                {
                    { "x-rapidapi-key", "4e4a7e4304mshec7fc0b407a4e13p1dcd8bjsn6a8b0f49b2d8" },
                    { "x-rapidapi-host", "weatherbit-v1-mashape.p.rapidapi.com" },
                },
            };

            _logger.LogInformation("Sending HTTP request to weather API...");
            using (var response = await httpClient.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var weatherRoot = JsonConvert.DeserializeObject<WeatherDTO>(responseBody);

                    if (weatherRoot != null)
                    {
                        // Map DTO to Entity
                        //var weatherEntity = _mapper.Map<Weather>(weatherDto);
                        var weatherEntity = new Weather
                        {
                            city_name = weatherRoot.city_name,
                            state_code = weatherRoot.state_code,
                            country_code = weatherRoot.country_code,
                            timezone = weatherRoot.timezone,
                            lon = weatherRoot.lon,
                            lat = weatherRoot.lat,
                        };

                        context.Weathers.Add(weatherEntity);
                        context.SaveChanges();

                        var dataPointsList = weatherRoot.data.Select(d =>  new Datum
                        {
                            WeatherId = weatherEntity.Id,
                            pod = d.pod,
                            pres = d.pres,
                            clouds = d.clouds,
                            vis = d.vis,
                            wind_spd = d.wind_spd,
                            wind_cdir_full = d.wind_cdir_full,
                            slp = d.slp,
                            datetime = d.datetime,
                            ts = d.ts,
                            dewpt = d.dewpt,
                            uv = d.uv,
                            dni = d.dni,
                            timestamp_utc = d.timestamp_utc.HasValue ? DateTime.SpecifyKind(d.timestamp_utc.Value, DateTimeKind.Utc) : (DateTime?)null,
                            ghi = d.ghi,
                            dhi = d.dhi,
                            timestamp_local = d.timestamp_local.HasValue ? DateTime.SpecifyKind(d.timestamp_local.Value, DateTimeKind.Utc) : (DateTime?)null,
                            temp = d.temp,
                            app_temp = d.app_temp,
                            snow = d.snow,
                            solar_rad = d.solar_rad,
                            pop = d.pop,
                            ozone = d.ozone,
                            clouds_hi = d.clouds_hi,
                            clouds_low = d.clouds_low,
                            clouds_mid = d.clouds_mid,
                            wind_cdir = d.wind_cdir,
                            wind_dir = d.wind_dir,
                            precip = d.precip,
                            wind_gust_spd = d.wind_gust_spd,
                            snow_depth = d.snow_depth,
                            rh = d.rh
                        }).ToList();

                        context.DataPoints.AddRange(dataPointsList);
                        await context.SaveChangesAsync();

                        _logger.LogInformation("Weather data saved successfully.");
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
