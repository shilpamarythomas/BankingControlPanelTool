﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ViewModel
{
    public class UserAddressVM
    {        
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
    }
}
