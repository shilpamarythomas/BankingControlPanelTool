using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Common
{
    [Table("Cities")]
    public class Cities : BaseEntity
    {
        public string CityName { get; set; }
        public int CountryId { get; set; }
    }
}
