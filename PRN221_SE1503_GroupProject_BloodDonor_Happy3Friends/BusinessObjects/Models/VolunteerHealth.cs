using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.Models
{
    [Display(Name = "Hồ sơ sức khỏe")]
    public partial class VolunteerHealth
    {
        public VolunteerHealth()
        {
            VolunteerInCampaigns = new HashSet<VolunteerInCampaign>();
        }

        public int Id { get; set; }

        [Display(Name = "Chiều cao")]
        public int? Height { get; set; }

        [Display(Name = "Cân nặng")]
        public double? Weight { get; set; }

        [Display(Name = "Có vi rút viêm gan B")]
        public bool? HaveHepatitisBvirus { get; set; }

        [Display(Name = "Có vi rút HIV")]
        public bool? HaveHivvirus { get; set; }

        [Display(Name = "Bệnh khác")]
        public string OtherDiseases { get; set; }

        public virtual ICollection<VolunteerInCampaign> VolunteerInCampaigns { get; set; }
    }
}
