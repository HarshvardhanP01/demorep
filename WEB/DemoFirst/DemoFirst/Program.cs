using DemoFirst.BizLayer.Contracts;
using DemoFirst.BizLayer.Services;

namespace DemoFirst
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //Transient- for each req new object useful for lightweight and indepenedent object.
            //for depedency within object go for scope.
            //singletone name suggests.- sessionspeicific 
            builder.Services.AddTransient<IMyService,MyClassV1>();
            builder.Services.AddTransient<IMyService,MyClassV2>();
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles(); // for html css js 

            app.UseRouting();

            // app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
