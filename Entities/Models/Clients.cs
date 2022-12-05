using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;
using System.Net;

namespace Entities.Models
{
    [Table("Clients")]
    public partial class Clients : BaseEntity
    {
        public Clients()
        {
            Address = new HashSet<UserAddress>();
            Accounts = new HashSet<Accounts>();
        }

        [Required]
        
        public string Email { get; set; }
        [Required]
        [MaxLength(60)]
        
        public string FirstName { get; set; }
        [Required]
        [MaxLength(60)]
        public string LastName { get; set; }
        [Required]
        public string PersonalId { get; set; }
        public string ProfilePhoto { get; set; }
        [Required]
        public string MobileNo { get; set; }
        [Required]
        public string Sex { get; set; }
        public int CreatedBy { get; set; }
        public virtual ICollection<UserAddress>? Address { get; set; }
        public virtual ICollection<Accounts>? Accounts { get; set; }
        public string CountryCode { get; set; }
    }
}
