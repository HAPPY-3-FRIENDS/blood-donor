using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObjects.Models
{
    public partial class BloodRequest
    {
        public int Id { get; set; }
        public string VolunteerId { get; set; }
        public int OrganizationId { get; set; }
        public DateTime RequestDate { get; set; }
        public string Description { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverIdentityNumber { get; set; }
        public string Status { get; set; }

        public virtual Organization Organization { get; set; }
        public virtual Volunteer Volunteer { get; set; }
    }
}
