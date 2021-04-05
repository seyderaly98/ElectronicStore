using System;
using Microsoft.AspNetCore.Identity;

namespace ElectronicStore.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birth { get; set; }
        public DateTime CrateDate { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}