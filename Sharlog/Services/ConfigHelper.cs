using System;
using Sharlog.Implements;
namespace Sharlog.Services
{
	public class ConfigHelper : IConfigHelper
	{
		public ConfigHelper()
		{
		}

        public object ReadDBConfig(string? configType = "basic")
        {
            throw new NotImplementedException();
        }

        public string ReadJSONConfig(string configType)
        {
            throw new NotImplementedException();
        }

        public void SaveConfigDB(object configReference, string? configType = "basic")
        {
            throw new NotImplementedException();
        }

        public void SaveConfigJSON(string json)
        {
            throw new NotImplementedException();
        }
    }
}

