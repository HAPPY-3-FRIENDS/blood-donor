using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObjects.Models
{
    public partial class Volunteer
    {
        public Volunteer()
        {
            BloodRequests = new HashSet<BloodRequest>();
            VolunteerInCampaigns = new HashSet<VolunteerInCampaign>();
        }

        public string Phone { get; set; }
        public string Name { get; set; }
        public string IdentityNumber { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string AddressDetails { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string BloodType { get; set; }
        public DateTime? LastDonationDate { get; set; }

        public virtual ICollection<BloodRequest> BloodRequests { get; set; }
        public virtual ICollection<VolunteerInCampaign> VolunteerInCampaigns { get; set; }
    }
}
