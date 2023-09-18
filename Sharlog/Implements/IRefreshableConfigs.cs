using System;
namespace Sharlog.Implements
{
	public interface IRefreshableConfigs
	{
		//  !bool IsPluginConf;
		/// <summary>
		/// Function to Reload this configuration,
		/// in this case Applying new configurations won't need to restart entire.
		/// </summary>
		/// <returns>Nullable Boolean that can tell success or not. </returns>
		bool? Reload();

	}
}

