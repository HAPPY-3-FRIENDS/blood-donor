using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObjects.Models
{
    public partial class VolunteerInCampaign
    {
        public int Id { get; set; }
        public string VolunteerId { get; set; }
        public int CampaignId { get; set; }
        public int? DonatedBloodId { get; set; }
        public int VolunteerHealthId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime DonatedDate { get; set; }

        public virtual Campaign Campaign { get; set; }
        public virtual DonatedBlood DonatedBlood { get; set; }
        public virtual Volunteer Volunteer { get; set; }
        public virtual VolunteerHealth VolunteerHealth { get; set; }
    }
}
