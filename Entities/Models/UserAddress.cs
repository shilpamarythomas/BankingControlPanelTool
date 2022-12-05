using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Models.Common;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    [Table("UserAddress")]
    public partial class UserAddress : BaseEntity
    {
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public int CountryId { get; set; }
        //public virtual ICollection<Countries> AvailableCountries { get; set; }
        public int CityId { get; set; }
        //public virtual ICollection<Cities> AvailableCities { get; set; }
        [IgnoreDataMember]
        [JsonIgnore]
        public int? ClientId { get; set; }
        [IgnoreDataMember]
        [JsonIgnore]
        public virtual Clients? Client { get; set; }
    }
}
