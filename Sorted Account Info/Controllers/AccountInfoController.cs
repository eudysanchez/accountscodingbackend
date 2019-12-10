using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SortedAccountInfo.Services;

namespace Sorted_Account_Info.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountInfoController : ControllerBase
    {
        private readonly IAccountInfoService _accountInfoService;

        public AccountInfoController(IAccountInfoService accountInfoService)
        {
            _accountInfoService = accountInfoService;
        }
        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetAccountInfo()
        {
            var response = await _accountInfoService.GetAccountInformation();
            return Ok(response);
        }

    }
}
