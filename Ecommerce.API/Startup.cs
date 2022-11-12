using Ecommerce.BL.Abstract;
using Ecommerce.BL.Concrete;
using Ecommerce.DAL.Abstract;
using Ecommerce.DAL.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Ecommerce.API
{
    public class Startup
    {

        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(
                     "AllowOrigin",
                     builder =>
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            services.AddControllers();

            services.AddScoped<ICategoryDAL, CategoryDAL>(p => new CategoryDAL(_configuration.GetConnectionString("connStr")));
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IProductDAL, ProductDAL>(p => new ProductDAL(_configuration.GetConnectionString("connStr")));
            services.AddScoped<IProductService, ProductService>();

            services.AddSwaggerDocument( config =>
            {
                config.PostProcess = (doc =>
                {
                    doc.Info.Title = " All E-Commerce API";
                    doc.Info.Version= "v1";

                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseCors(x =>
            {
                x.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
