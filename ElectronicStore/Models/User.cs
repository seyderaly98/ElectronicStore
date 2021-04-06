using System;
using System.Collections.Generic;
using ElectronicStore.ViewModel;
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

        public virtual List<Shop> Shops { get; set; }
        
        public User()
        {
        }
        public User(Register model)
        {
            Email = model.Email;
            Name = model.Name;
            Surname = model.SurName;

        }
    }
}