using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Codestellar.BackgroundService
{
    public class MyBackgroundService : IHostedService, IDisposable
    {
        private readonly ILogger<MyBackgroundService> logger;
        private Timer timer;
        private int number;

        public MyBackgroundService(ILogger<MyBackgroundService> logger)
        {
            this.logger = logger;
        }

        public void Dispose()
        {
            timer?.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            timer = new Timer(t =>
            {
                logger.LogInformation($"Running Background Service {++number}");
                logger.LogInformation($"Consuming {Process.GetCurrentProcess().WorkingSet64/1024/1024} MB physical Memory");

            }, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
