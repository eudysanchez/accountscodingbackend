using System;
using Xunit;
using FluentAssertions;
using Moq;
using SortedAccountInfo.Services;
using Sorted_Account_Info.Controllers;
using AutoFixture;
using SortedAccountInfo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace SortedAccountInfoTests
{
    public class AccountInfoControllerTests
    {
        private readonly Mock<IAccountInfoService> _accountInfoServiceMock;
        private readonly AccountInfoController _accountInfoController;
        private Fixture _fixture;

        public AccountInfoControllerTests()
        {
            _fixture = new Fixture();
            _accountInfoServiceMock = new Mock<IAccountInfoService>();
            _accountInfoController = new AccountInfoController(_accountInfoServiceMock.Object);
        }

        [Fact]
        public async Task GetAccountInfo_SuccessfulRequest_CallsGetAccountInformationService()
        {
            var fakeAccountInfoData = GetFakeAccountInfoData();
            _accountInfoServiceMock.Setup(x => x.GetAccountInformation()).ReturnsAsync(fakeAccountInfoData);

            var response = await _accountInfoController.GetAccountInfo();

            _accountInfoServiceMock.Verify(x => x.GetAccountInformation(), Times.Once);
        }

        [Fact]
        public async Task GetAccountInfo_SuccessfulRequest_ReturnsOK()
        {
            var fakeAccountInfoData = GetFakeAccountInfoData();
            _accountInfoServiceMock.Setup(x => x.GetAccountInformation()).ReturnsAsync(fakeAccountInfoData);

            var response = await _accountInfoController.GetAccountInfo() as OkObjectResult;

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(StatusCodes.Status200OK);
            response.Value.Should().BeEquivalentTo(fakeAccountInfoData);
        }

        private IEnumerable<AccountInformation> GetFakeAccountInfoData()
        {
            IEnumerable<AccountInformation> fakeAccountInformation = _fixture.CreateMany<AccountInformation>(5);
            return fakeAccountInformation;
        }
    }
}
