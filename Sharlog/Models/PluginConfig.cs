using Sharlog.Implements;
using System.Text.Json.Nodes;

namespace Sharlog.Models
{
    public class PluginConfig : IRefreshableConfigs
    {
        public string PluginName { get; set; }
        public string? PluginType { get; set; }
        public string? PluginInfo { get; set; }
        public string? PluginAuthor { get; set; }
        public string PluginVersion { get; set; } = "1";
        public string PluginAssetsPath { get; set; } = "./assets";
        public string[]? PluginJsonPath { get; set; }
        public FileInfo? ReadableConfig { get; set; }

        public DirectoryInfo? PluginDirInfo { get; set; }

        public PluginConfig(string name, string? type, string? info, string? author, string path, string[]? jpath, string ver = "1") 
        {
            this.PluginName = name;
            this.PluginType = type; 
            this.PluginInfo = info;
            this.PluginAuthor = author;
            this.PluginVersion = ver;
            this.PluginAssetsPath = path;
            this.PluginJsonPath = jpath;
        }
        public bool? Reload()
        {
            //  read dedicated json to here and overwrite this.ReadableConfig
            Console.WriteLine($"[Plugin] - [{this.PluginName} ({this.PluginVersion})]: Reloading...");
            try 
            {
                // if path pair to PluginType not exist, alert. Since a plugin must has assets path provided by author, then should alert. in the future, can add checkment of Integrity...

                return true;
            }catch(Exception e) { Console.WriteLine(e.ToString()); return false; }
            // throw new NotImplementedException();
        }
    }
}
