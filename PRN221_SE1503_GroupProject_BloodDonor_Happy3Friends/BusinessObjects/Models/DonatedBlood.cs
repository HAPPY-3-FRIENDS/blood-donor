using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObjects.Models
{
    public partial class DonatedBlood
    {
        public DonatedBlood()
        {
            VolunteerInCampaigns = new HashSet<VolunteerInCampaign>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public int Amount { get; set; }

        public virtual ICollection<VolunteerInCampaign> VolunteerInCampaigns { get; set; }
    }
}
