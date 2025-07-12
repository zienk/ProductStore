using DataAccessLayer.Models;
using Repositories.Implements;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implements
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService()
        {
            _accountRepository = new AccountRepository();
        }

        public AccountMember GetAccountById(string accountID)
            => _accountRepository.GetAccountById(accountID);
    }
}
