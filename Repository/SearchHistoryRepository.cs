using Contracts;
using Contracts.ViewModel;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SearchHistoryRepository : RepositoryBase<SearchHistory>, ISearchHistoryRepository
    {
        private readonly RepositoryContext _repositoryContext;
        public SearchHistoryRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public void AddSearchHistory(string SearchParameter)
        {
            var input = new SearchHistory()
            {
                SearchDateTime = DateTime.Now,
                SearchParameter = SearchParameter
            };
            Create(input);
            SaveChange();
        }
        public IEnumerable<SearchHistory> GetSearchHistory()
        {
            return _repositoryContext.SearchHistory.OrderByDescending(x => x.SearchDateTime).Take(3);
        }
    }
}
