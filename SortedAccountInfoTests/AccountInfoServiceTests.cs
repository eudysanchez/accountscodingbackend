using FluentAssertions;
using SortedAccountInfo.Models;
using SortedAccountInfo.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SortedAccountInfoTests
{
    public class AccountInfoServiceTests
    {
        public AccountInfoServiceTests()
        {

        }
        [Fact]
        public async Task GetAccountInformation_ReadsDateFromFile_DataIsLoaded()
        {
            var accountInfoService = new AccountInfoService();
            //_accountInfoServiceMock.Setup(x => x.GetAccountInformation()).ReturnsAsync(fakeAccountInfoData);

            var data = await accountInfoService.GetAccountInformation() as List<AccountInformation>;

            data.Should().NotBeEmpty();
            //TODO: this can be done like this because the data is static
            data.Count.Should().Be(7);
        }
    }
}
