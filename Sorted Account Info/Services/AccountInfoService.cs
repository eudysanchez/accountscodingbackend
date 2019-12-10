using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using SortedAccountInfo.Models;

namespace SortedAccountInfo.Services
{
    public class AccountInfoService : IAccountInfoService
    {
        public AccountInfoService()
        {

        }
        public Task<IEnumerable<AccountInformation>> GetAccountInformation()
        {
            IEnumerable<AccountInformation> accountInformation = new List<AccountInformation>();
            using (StreamReader file = new StreamReader(@".\AccountInformationData.json"))
            {
                string json = file.ReadToEnd();
                accountInformation = JsonConvert.DeserializeObject<List<AccountInformation>>(json);
            }
            return Task.FromResult(accountInformation);
            //JObject o1 = JObject.Parse(File.ReadAllText(@".\AccountInformationData.json"));
        }
    }
}
