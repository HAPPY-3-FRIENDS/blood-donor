using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObjects.Models
{
    public partial class VolunteerHealth
    {
        public VolunteerHealth()
        {
            VolunteerInCampaigns = new HashSet<VolunteerInCampaign>();
        }

        public int Id { get; set; }
        public string DiseaseName { get; set; }
        public string DiseaseDescription { get; set; }
        public string Status { get; set; }

        public virtual ICollection<VolunteerInCampaign> VolunteerInCampaigns { get; set; }
    }
}
