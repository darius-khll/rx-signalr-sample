using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.SignalR.Infrastructure;

namespace rx_signalr_sample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDirectoryBrowser();

            services.AddSignalR(options =>
            {
                options.Hubs.EnableDetailedErrors = true;
                options.Hubs.EnableJavaScriptProxies = true;
            });
        }

        public void Configure(IApplicationBuilder app, IConnectionManager signalrConnectionManager)
        {
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseWebSockets();
            app.UseSignalR();

            Test(signalrConnectionManager);
        }

        public async void Test(IConnectionManager signalrConnectionManager)
        {
            signalrConnectionManager.GetHubContext<SampleHub>()
                .Clients.All.test(1);

            await Task.Delay(1000);

            Test(signalrConnectionManager);
        }
    }
}
