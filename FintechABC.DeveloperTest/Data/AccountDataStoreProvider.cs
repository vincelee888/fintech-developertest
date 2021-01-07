namespace FintechABC.DeveloperTest.Data
{
    public class AccountDataStoreProvider
    {
        private readonly IConfiguration _configuration;

        public AccountDataStoreProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public IAccountDataStore GetAccountDataStore()
        {
            return _configuration.ShouldUseBackupDataStore switch
            {
                true => new BackupAccountDataStore(),
                _ => new AccountDataStore()
            };
        }
    }
}
