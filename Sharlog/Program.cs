using System;
using System.Runtime.Loader;
using Sharlog;
using Sharlog.Helpers;
using Sharlog.Models;

Initialize.A();

var _basic = new BasicConfigs();
var _settings = new SettingsTools();
var _plugget = new PluginGetter();

var localDir = new DirectoryInfo("./Sharlog");
if (!localDir.Exists)
{
    localDir.Create();
    // continue creating folders else...
    Directory.CreateDirectory("./Sharlog/Plugin");
    Directory.CreateDirectory("./Sharlog/E");
    File.CreateText("./Sharlog/basic.json");

}

_plugget.GetPlugins();

AssemblyLoadContext.Default.Resolving += (context, name) =>
{
    // Replace "path_to_your_dlls" with the actual path to your DLLs
    var assemblyPath = $"Sharlog/Plugin/{name.Name}.dll";
    if (System.IO.File.Exists(assemblyPath))
    {
        return context.LoadFromAssemblyPath(assemblyPath);
    }
    return null;
};

Console.WriteLine($"=======\nCompleted Preparation, about to launch Blazor framework...\nCurrent Working Directory: {Environment.CurrentDirectory}\n=======\n");
Initialize.X(args);