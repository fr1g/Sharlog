using System;
namespace Sharlog.SharSkript
{
	public interface ISkriptVariableActions
	{
		void AddVar(string name, object come);
		void DelVar(string name);
		void ChangeVar(string name, object come, string type);
		object GetVar(string name);
	}
}

