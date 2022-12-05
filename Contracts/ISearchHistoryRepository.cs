using Contracts.ViewModel;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ISearchHistoryRepository : IRepositoryBase<SearchHistory>
    {
        public void AddSearchHistory(string SearchParameter);
        public IEnumerable<SearchHistory> GetSearchHistory();
    }
}
