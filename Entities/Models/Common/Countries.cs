using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Common
{
    [Table("Countries")]
    public class Countries : BaseEntity
    {
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
    }
}
