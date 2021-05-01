using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(ЛР_1.Areas.Identity.IdentityHostingStartup))]
namespace ЛР_1.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}