using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AccountDAO
    {
        public static AccountMember GetAccountById(string accountId)
        {
            using var context = new Context.MyStoreContext();
            return context.AccountMembers.FirstOrDefault(c => c.MemberId.Equals(accountId));
        }
    }
}
