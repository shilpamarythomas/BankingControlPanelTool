using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    [Table("Accounts")]
    public partial class Accounts : BaseEntity
    {
        [MaxLength(500)]
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string IBANNumber { get; set; }
        [IgnoreDataMember]
        [JsonIgnore]
        public int? ClientId { get; set; }
        [IgnoreDataMember]
        [JsonIgnore]
        public virtual Clients? Client { get; set; }
        public int CreatedBy { get; set; }

    }
}
