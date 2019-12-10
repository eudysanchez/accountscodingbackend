using SortedAccountInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SortedAccountInfo.Services
{
    public interface IAccountInfoService
    {
        Task<IEnumerable<AccountInformation>> GetAccountInformation();
    }
}
