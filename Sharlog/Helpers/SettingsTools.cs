using System;
using Sharlog.Models;

namespace Sharlog.Helpers
{
    public class SettingsTools
    {
        
        private string? _temp; // temporary settings, which read the elder and cover newer later
        private readonly BasicConfigs _basicDefault = new()
        {
            BlogName = "",
            BlogDescriptions = "",
            BlogSEO = "",
            BlogKeyWords = "",
            BlogContactEmail = "",
            BlogDatabase = "",
            BlogMainPageRedirect = "",
            BlogPageTitle = "",
            EnableTailwindCSS = true,
            BlockMudBlazor = false,
        };
        public void SetConfig(string type, string item) // 
        {

        }
        public void ResetConfig(string type, object defaultConfig) // reset entire config json
        {

        }
        public SettingsTools()
		{
		}
	}
}

