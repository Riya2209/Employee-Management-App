namespace Employee_Management_App;

    //public class Startup
    //{
    //}


using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Employee_Management_App.UtilClasses;


using Employee_Management_App.Context;


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
            // Configure DbContext
            services.AddDbContext<EmpContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Server=KAARLP-2178\\SQLEXPRESS;Database=Employee Management;Trusted_Connection=True;Encrypt=true;TrustServerCertificate=True")));

            // Configure MVC
            services.AddControllersWithViews();

            // Add other services here
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipelinehxcg
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }

