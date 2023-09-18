using System;
using Sharlog.Implements;
namespace Sharlog.Models
{
	public class ExternalAssetsConfig : IRefreshableConfigs // singleton on startup
	{

		protected Dictionary<string, PluginConfig> PluginList;


		public void Register(PluginConfig cfg) 
		{
			PluginList.Add(cfg.PluginName, cfg);
			Console.WriteLine($"[Plugins] New config of Plugin GOT: {cfg.ToString()}");
		}
		public bool? Reload()
		{

			return null;
		}

		public ExternalAssetsConfig()
		{
			PluginList = new Dictionary<string, PluginConfig>();
		}
	}
}

