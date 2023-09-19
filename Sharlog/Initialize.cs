using System;
using System.Text.Json;
using System.Runtime.Loader;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using Sharlog.Areas.Identity;
using Sharlog.Data;
using Sharlog.Models;

namespace Sharlog
{
    public class GlobalVariableScope
    {

    }
    public class PluginGetter
    {
        public ExternalAssetsConfig EACReference = new();
        public void GetPlugins()
        {
            DirectoryInfo di = new("./Sharlog/Plugin");
            DirectoryInfo[] dirs = di.GetDirectories();
            foreach (var dir in dirs)
            {
                if (!File.Exists($"{dir.FullName}/config.json")) continue;
                else try
                    {
                        FileInfo configJsonFile = new($"{dir.FullName}/config.json");
                        string pluginJson = "";
                        using (StreamReader sr = new(configJsonFile.FullName))
                        {
                            while (!sr.EndOfStream)
                            {
                                string? line = sr.ReadLine();
                                if (line is null) continue;
                                pluginJson += line;
                            }
                            sr.Close();
                        }
                        PluginConfig? plugin = JsonSerializer.Deserialize<PluginConfig>(pluginJson); // NEED TEST
                        if (plugin is null) throw new Exception(); // ?

                        Console.WriteLine($"[Plugin] - Successfully Located Plugin: {dir.Name}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"======\nError Occured: Loading Plugin Directory: {dir.Name} \nTrace:\n{ex.StackTrace}\n=====END=====\n");
                    }
            }
        }
    }
	public static class Initialize
	{

        // Essentials: 
        public static string V = "version:alpha-1.0-i;dev";
        public static void A()
        {
            Console.WriteLine("""
                 ===   =  =    ==    ===
                =      ====   =  =   =  =
                 ===   =  =   ====   ===
                    =  =  =   =  =   =  =
                 ===   =  =   =  =   =   =
                """);
            Console.WriteLine($"Welcome to SharLog! {V}\n");
        }
		public static void X(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            builder.Services.AddSingleton<WeatherForecastService>();

            builder.Services.AddMudServices();

            // builder.Services.AddSingleton(IHostEnvironment);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            //app.Services.CreateScope();
            app.MapControllers();
            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");
//#//
            app.Run();
        }

		
	}
}

