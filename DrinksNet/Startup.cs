using DrinksNet.AuxApi;
using DrinksNet.DAL;
using DrinksNet.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DrinksNet
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigin = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICocktailRepository,CocktailRepository>();
            services.AddScoped<IUserDrinkRepository, UserDrinkRepository>();
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IUserDrinksDataAccessLayer, UserDrinksDataAccessLayer>();
            services.AddScoped<IUsersDataAccessLayer, UsersDataAccessLayer>();

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigin,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:5001")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowAnyOrigin();
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

            app.UseCors(MyAllowSpecificOrigin);

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
