using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObjects.Models
{
    public partial class Campaign
    {
        public Campaign()
        {
            VolunteerInCampaigns = new HashSet<VolunteerInCampaign>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AddressDetails { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int OrganizationId { get; set; }

        public virtual Organization Organization { get; set; }
        public virtual ICollection<VolunteerInCampaign> VolunteerInCampaigns { get; set; }
    }
}
