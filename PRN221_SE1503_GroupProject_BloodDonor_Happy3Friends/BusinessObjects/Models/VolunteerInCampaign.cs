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
        public string BloodType { get; set; }
        public int? BloodAmount { get; set; }
        public int? VolunteerHealthId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? DonatedDate { get; set; }
        public string Status { get; set; }
        public string RejectedReason { get; set; }

        public virtual Campaign Campaign { get; set; }
        public virtual Volunteer Volunteer { get; set; }
        public virtual VolunteerHealth VolunteerHealth { get; set; }
    }
}
