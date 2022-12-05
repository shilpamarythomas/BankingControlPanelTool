using Entities.Models;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Models.Common;

namespace Repository
{
    public class UserRolesRepository : RepositoryBase<UserRoles>, IUserRolesRepository
    {
        private readonly RepositoryContext _repositoryContext;
    
        public UserRolesRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public List<UserRoles> GetUserRoles()
        {
            return _repositoryContext?.UserRoles?.ToList();
        }
    }
}
