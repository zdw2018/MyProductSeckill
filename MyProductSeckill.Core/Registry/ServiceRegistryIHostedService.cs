using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace MyProductSeckill.Core.Registry
{
    public class ServiceRegistryIHostedService : IHostedService
    {
        private readonly IServiceRegistry serviceRegistry;
        public ServiceRegistryIHostedService(IServiceRegistry serviceRegistry)
        {
            this.serviceRegistry = serviceRegistry;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.Run(() => serviceRegistry.Register());
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            serviceRegistry.DeRegister();
            return Task.CompletedTask;
            //return Task.Run(() => serviceRegistry.DeRegister());
        }
    }
}