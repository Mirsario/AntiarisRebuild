using log4net.Core;
using log4net.Repository.Hierarchy;

namespace Antiaris
{
	public static class ErrorLogger
	{
		public readonly ILogger Logger = new Logger();
	}
}
