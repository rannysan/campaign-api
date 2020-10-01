using CampaignApi.Models;
using CampaignApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using UserApi.Services;

namespace CampaignApi
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
            // requires using Microsoft.Extensions.Options
            services.Configure<CampaignDatabaseSettings>(
                Configuration.GetSection(nameof(CampaignDatabaseSettings)));

            services.AddSingleton<ICampaignDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<CampaignDatabaseSettings>>().Value);

            services.AddSingleton<CustomerService>();
            services.AddSingleton<CampaignService>();
            services.AddSingleton<UserService>();
            services.AddSingleton<RecordService>();
            services.AddSingleton<PrizeService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
