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

        public PluginConfig CreatePluginConfig(string name, string? type, string? info, string? author, string path, string[]? jpath, string ver = "1")
        {
            return new PluginConfig {
                PluginName = name,
                PluginType = type,
                PluginInfo = info,
                PluginAuthor = author,
                PluginVersion = ver,
                PluginAssetsPath = path,
                PluginJsonPath = jpath,
            };
        }

        // 插件配置应该存在数据库的！！！！！！json提供默认值！！！！！刷新的原理是把内存中旧的引用使用存入数据库的新配置覆盖！！！！
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
