using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SortedAccountInfo.Models
{
    public class AccountInformation
    {
        //{"Id":1,"FirstName":"Emma","LastName":"Smith","Email":"emma.smith@email.com","PhoneNumber":"5555559483","AmountDue":84.22,
        //"PaymentDueDate":"2019-12-12T00:00:00+00:00","AccountStatusId":0}
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Currency)]
        public string PhoneNumber { get; set; }
        public decimal AmountDue { get; set; }
        public DateTimeOffset? PaymentDueDate { get; set; }
        public AccountStatuses AccountStatusId { get; set; }
    }
}
