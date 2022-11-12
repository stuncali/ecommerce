using Ecommerce.BL.Abstract;
using Ecommerce.BL.Concrete;
using Ecommerce.DAL.Abstract;
using Ecommerce.DAL.Concrete;
using Ecommerce.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Ecommerce.Web
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public static string apiUrl="";

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            apiUrl = _configuration.GetSection("ApiUrl").GetValue<string>("url");
            services.AddScoped<ICategoryDAL,CategoryDAL>(p=> new CategoryDAL(_configuration.GetConnectionString("connStr")));
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IProductDAL, ProductDAL>(p=> new ProductDAL(_configuration.GetConnectionString("connStr")));
            services.AddScoped<IProductService, ProductService>();

            services.AddSingleton<ICartService, CartService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ICartSessionService, CartSessionService>();

            services.AddSession();
            services.AddDistributedMemoryCache();

            services.AddControllersWithViews();
        }

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

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
