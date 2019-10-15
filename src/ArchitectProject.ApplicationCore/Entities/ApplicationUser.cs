using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArchitectProject.ApplicationCore.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base() { }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string AvatarImage { get; set; }
    }
}
