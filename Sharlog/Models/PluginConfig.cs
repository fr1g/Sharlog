using Sharlog.Implements;
using System.Text.Json.Nodes;

namespace Sharlog.Models
{
    public class PluginConfig : IRefreshableConfigs
    {
        public string PluginName;
        public string? PluginType;
        public string? PluginInfo;
        public string PluginVersion = "1";
        public string PluginAssetsPath;
        public string? PluginJsonPath;
        public JsonObject? ReadableConfig;

        public PluginConfig(string name, string? type, string? info, string path, string? jpath, string ver = "1") 
        {
            this.PluginName = name;
            this.PluginType = type; 
            this.PluginInfo = info;
            this.PluginVersion = ver;
            this.PluginAssetsPath= path;
        }
        public bool? Reload()
        {
            //  read dedicated json to here and overwrite this.ReadableConfig
            Console.WriteLine($"[Plugin] - [{this.PluginName} ({this.PluginVersion})]: Reloading...");
            try 
            {
                // if path not exist, alert. Since a plugin must has assets path provided by author, then should alert. in the future, can add checkment of Integrity...

                return true;
            }catch(Exception e) { Console.WriteLine(e.ToString()); return false; }
            // throw new NotImplementedException();
        }
    }
}
