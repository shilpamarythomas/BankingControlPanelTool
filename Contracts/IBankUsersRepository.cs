using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Contracts.ViewModel;

namespace Contracts
{
    public interface IBankUsersRepository : IRepositoryBase<BankUsers>
    {
        BankUsers CreateBankUser(CreateUserVM registerVM, byte[] passwordHash, byte[] passwordSalt);
        BankUsers GetUsers(string username);
        BankUsers GetUsersById(int userId);
    }
}
