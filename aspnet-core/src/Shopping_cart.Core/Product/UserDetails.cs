using Microsoft.AspNetCore.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_cart.Models
{
    public class UserDetails : IdentityUser
    {

        public string Name { get; set; }
        public ICollection<AddressInfo> Addresses { get; set; }
        
        
    }
}

