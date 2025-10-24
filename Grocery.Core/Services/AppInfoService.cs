using System.Reflection;
using Grocery.Core.Interfaces.Services;

namespace Grocery.Core.Services
{
    public class AppInfoService : IAppInfoService
    {
        public string GetAppVersion()
        {
            // Get version out of main Assembly
            var version = Assembly.GetEntryAssembly().GetName().Version;
            return $"v{version.Major}.{version.Minor}.{version.Build}";
        }
    }
}