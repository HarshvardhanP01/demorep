using BurgerShopAPI.Data;
using Humanizer;
using Microsoft.EntityFrameworkCore;

namespace BurgerShopAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {

                var builder = WebApplication.CreateBuilder(args);

                // Add services to the container.

                builder.Services.AddDbContext<OrderContext>(options =>

                    options.UseSqlServer(builder.Configuration.GetConnectionString("cs")));
            builder.Services.AddControllers(options =>
          options.RespectBrowserAcceptHeader = true

           ).AddXmlDataContractSerializerFormatters();



                builder.Services.AddEndpointsApiExplorer();

                builder.Services.AddSwaggerGen();

             
                var app = builder.Build();

                // Configure the HTTP request pipeline.

                if (app.Environment.IsDevelopment())

                {

                    app.UseSwagger();

                    app.UseSwaggerUI();

                }

                app.UseHttpsRedirection();

                app.UseAuthorization();

                app.MapControllers();
                app.UseStaticFiles();

                app.Run();

         }

    }

 }
