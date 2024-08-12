using Quartz;

namespace WebAPI_week1.WeatherWorkers
{
    public class WeatherWorker : BackgroundService
    {
        private readonly ILogger<WeatherWorker> _logger;
        private readonly IScheduler _scheduler;

        public WeatherWorker(ILogger<WeatherWorker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken cancelationToken)
        {
            while (!cancelationToken.IsCancellationRequested)
            {
                _logger.LogInformation("WeatherWorker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, cancelationToken);
            }
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            await _scheduler.Shutdown();
            await base.StopAsync(cancellationToken);
        }
    }
}
