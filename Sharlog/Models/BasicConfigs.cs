using System;
namespace Sharlog.Models
{
	public class BasicConfigs
	{
		public string BlogName { get; set; } = "Another Blog by Sharlog";
		public string BlogKeyWords { get; set; } = "Sharlog.NET";
		public string BlogDescriptions { get; set; } = "Share Everything";
		public string BlogSEO { get; set; } = "Personal-Blog, Sharlog";
		public string? BlogContactEmail { get; set; }
		public string BlogHostName { get; set; } = "shar-log.net";
		public string BlogPageTitle { get; set; } = "Sharlog Blog Engine";
		public string? Blog { get; set; } // ?
		public string BlogMainPageRedirect { get; set; } = "/";
		public string? BlogDatabase { get; set; }

		public bool? EnableTailwindCSS { get; set; }
		public bool? BlockMudBlazor { get; set; }
        //public string[]? Plugins { get; set; }
        /*
         NOTE::
          1. about theme overriding and injection of plugin UI:
          2. about applying configurations


         */
        public BasicConfigs()
		{
		}
	}
}

