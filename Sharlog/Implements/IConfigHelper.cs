using System;
namespace Sharlog.Implements
{
	public interface IConfigHelper
	{
		string ReadJSONConfig(string configType); // read config into model
		void SaveConfigJSON(string json);

		object ReadDBConfig(string? configType = "basic");
		void SaveConfigDB(object configReference, string? configType = "basic");
		
	}
}

