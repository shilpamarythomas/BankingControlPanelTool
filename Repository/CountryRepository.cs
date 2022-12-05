using Contracts;
using Entities;
using Entities.Models;
using Entities.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CountryRepository : RepositoryBase<Countries>, ICountryRepository
    {
        private readonly RepositoryContext _repositoryContext;
        public CountryRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public string GetCountries(int CountryId)
        {
            var countrycode = _repositoryContext.Countries.Where(x => x.Id == CountryId).Select(x => x.CountryCode);
            return countrycode.ToString();
        }

    }
}
