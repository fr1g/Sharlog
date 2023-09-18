using System;
using System.Runtime.Loader;
using Sharlog;

AssemblyLoadContext.Default.Resolving += (context, name) =>
{
    // Replace "path_to_your_dlls" with the actual path to your DLLs
    var assemblyPath = $"Depend/{name.Name}.dll";
    if (System.IO.File.Exists(assemblyPath))
    {
        return context.LoadFromAssemblyPath(assemblyPath);
    }
    return null;
};

var localDir = new DirectoryInfo("./Sharlog");
if (!localDir.Exists)
{
    localDir.Create();
    // continue creating folders else...

}

Initialize.X(args);