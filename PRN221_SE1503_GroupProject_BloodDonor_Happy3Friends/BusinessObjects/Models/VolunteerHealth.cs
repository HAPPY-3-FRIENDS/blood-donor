using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class VolunteerHealth
    {
        public VolunteerHealth()
        {
            VolunteerInCampaigns = new HashSet<VolunteerInCampaign>();
        }

        public int Id { get; set; }
        public int? Height { get; set; }
        public double? Weight { get; set; }
        public bool? HaveHepatitisBvirus { get; set; }
        public bool? HaveHivvirus { get; set; }
        public string OtherDiseases { get; set; }

        public virtual ICollection<VolunteerInCampaign> VolunteerInCampaigns { get; set; }
    }
}
