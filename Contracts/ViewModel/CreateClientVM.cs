using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ViewModel
{
    public class CreateClientVM
    {
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Name should contain only alphabets.")]
        [StringLength(60)]
        public string FirstName { get; set; }
        [RegularExpression(@"^[A-Za-z]+$",ErrorMessage ="Name should contain only alphabets.")]
        [StringLength(60)]
        public string LastName { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z'.]{11}$",ErrorMessage ="Personal ID must be 11 characters.")]
        public string PersonalId { get; set; }
        public string ProfilePhoto { get; set; }
        public string MobileNo { get; set; }
        public string Sex { get; set; }
        public int CreatedBy { get; set; }
        public virtual List<UserAddressVM> Address { get; set; }
        public virtual List<AccountsVM> Accounts { get; set; }
        public string CountryCode { get; set; }
    }
    public class ClientVM : CreateClientVM
    {
        public int Id { get; set; }
    }
}
