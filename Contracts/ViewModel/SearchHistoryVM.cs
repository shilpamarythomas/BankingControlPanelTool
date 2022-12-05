using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ViewModel
{
    public class SearchHistoryVM
    {
        public string SearchParameter { get; set; }
        public DateTime SearchDateTime { get; set; }
    }
}
