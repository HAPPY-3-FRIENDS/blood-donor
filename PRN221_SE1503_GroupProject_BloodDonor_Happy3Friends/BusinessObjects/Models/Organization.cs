using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObjects.Models
{
    public partial class Organization
    {
        public Organization()
        {
            BloodRequests = new HashSet<BloodRequest>();
            Campaigns = new HashSet<Campaign>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AddressDetails { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public bool IsRedCross { get; set; }

        public virtual ICollection<BloodRequest> BloodRequests { get; set; }
        public virtual ICollection<Campaign> Campaigns { get; set; }
    }
}
