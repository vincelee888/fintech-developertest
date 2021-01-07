using FintechABC.DeveloperTest.Data;
using NSubstitute;
using NUnit.Framework;

namespace FintechABC.DeveloperTest.Tests.Data
{
    public class AccountDataStoreProviderTests
    {
        private IConfiguration _configuration;
        private AccountDataStoreProvider _sut;

        [SetUp]
        public void Setup()
        {
            _configuration = Substitute.For<IConfiguration>();
            _sut = new AccountDataStoreProvider(_configuration);
        }
        
        [Test]
        public void GivenNoConfigSetShouldReturnAccountDataStore()
        {
            var result = _sut.GetAccountDataStore();

            Assert.That(result, Is.TypeOf<AccountDataStore>());
        }
        
        [Test]
        public void GivenConfigSetToUseBackupShouldReturnBackupAccountDataStore()
        {
            _configuration
                .ShouldUseBackupDataStore
                .Returns(true);
            
            var result = _sut.GetAccountDataStore();

            Assert.That(result, Is.TypeOf<BackupAccountDataStore>());
        }
    }
}
