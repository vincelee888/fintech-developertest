using System.Configuration;

namespace FintechABC.DeveloperTest
{
    public class Configuration : IConfiguration
    {
        public bool ShouldUseBackupDataStore => ConfigurationManager.AppSettings["DataStoreType"] == "Backup";
    }
}
