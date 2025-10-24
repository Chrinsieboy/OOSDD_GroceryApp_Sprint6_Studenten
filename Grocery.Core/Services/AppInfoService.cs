using System.Reflection;
using Grocery.Core.Interfaces.Services;

namespace Grocery.Core.Services
{
    public class AppInfoService: IAppInfoService
    {
        // Voorbeeld: Implementeer in een nieuwe IAppInfoService of in een bestaande service.
        // Dit leest de versienummer uit de draaiende Assembly van de Presentatie Laag.
        public string GetAppVersion()
        {
            // Haal de versie uit de main Assembly
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            return $"v{version.Major}.{version.Minor}.{version.Build}";
        }
    }
}