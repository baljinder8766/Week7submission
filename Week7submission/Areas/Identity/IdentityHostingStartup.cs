using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Week7submission.Data;

[assembly: HostingStartup(typeof(Week7submission.Areas.Identity.IdentityHostingStartup))]
namespace Week7submission.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<UseridentyContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("UseridentyContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<UseridentyContext>();
            });
        }
    }
}