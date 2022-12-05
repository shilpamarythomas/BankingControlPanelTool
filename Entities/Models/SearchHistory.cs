using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("SearchHistory")]
    public class SearchHistory : BaseEntity
    {
        public string SearchParameter { get; set; }
        public DateTime SearchDateTime { get; set; }
    }
}
