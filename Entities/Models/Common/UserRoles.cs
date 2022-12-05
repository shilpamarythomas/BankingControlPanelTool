using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Common
{
    [Table("UserRoles")]
    public class UserRoles:BaseEntity
    {
        public string RoleName { get; set; }
    }
}
