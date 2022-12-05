using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Contracts;
using Contracts.ViewModel;
using Entities;
using Entities.Models;
using Entities.Models.Common;

namespace Repository
{
    public class BankUsersRepository : RepositoryBase<BankUsers>, IBankUsersRepository
    {
        private readonly RepositoryContext _repositoryContext;
        public static BankUsers user = new BankUsers();
        public BankUsersRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public BankUsers CreateBankUser(CreateUserVM registerVM, byte[] passwordHash, byte[] passwordSalt)
        {
            user.UserName = registerVM.UserName;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Email = registerVM.Email;
            user.FirstName = registerVM.FirstName;
            user.LastName = registerVM.LastName;
            user.Mobile = registerVM.Mobile;
            user.RoleId= registerVM.RoleId;

            Create(user);
            SaveChange();

            return user;
        }
        public BankUsers GetUsers(string username)
        {
            return _repositoryContext?.BankUsers?.Where(x => x.UserName == username).FirstOrDefault();
        }

        public BankUsers GetUsersById(int userId)
        {
            return _repositoryContext?.BankUsers?.Where(x => x.Id == userId).FirstOrDefault();
        }
    }
}
