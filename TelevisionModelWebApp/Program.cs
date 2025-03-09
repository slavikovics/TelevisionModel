using TelevisionModel;
using TelevisionModel.Utils;

namespace TelevisionModelWebApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        Television television = Saver.TryLoadFromFile();
        RemoteControl remoteControl = new RemoteControl(television);

        builder.Services.AddSingleton<Television>(television);
        builder.Services.AddSingleton<RemoteControl>(remoteControl);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Television}/{action=TurnOff}/{id?}");

        app.Run();
    }
}