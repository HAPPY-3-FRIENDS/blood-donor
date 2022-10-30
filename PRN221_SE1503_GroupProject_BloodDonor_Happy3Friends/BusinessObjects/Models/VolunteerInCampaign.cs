using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.Models
{
    public partial class VolunteerInCampaign
    {
        public int Id { get; set; }

        [Display(Name = "Tình nguyện viên")]
        public string VolunteerId { get; set; }

        [Display(Name = "Chiến dịch")]
        public int CampaignId { get; set; }

        [Display(Name = "Nhóm máu")]
        public string BloodType { get; set; }

        [Display(Name = "Lượng máu")]
        public int? BloodAmount { get; set; }

        [Display(Name = "Hồ sơ sức khỏe")]
        public int? VolunteerHealthId { get; set; }

        [Display(Name = "Ngày đăng ký")]
        public DateTime RegistrationDate { get; set; }

        [Display(Name = "Ngày tham gia hiến máu")]
        public DateTime? DonatedDate { get; set; }

        [Display(Name = "Trạng thái")]
        public string Status { get; set; }

        [Display(Name = "Lý do từ chối")]
        public string RejectedReason { get; set; }

        [Display(Name = "Chiến dịch")]
        public virtual Campaign Campaign { get; set; }

        [Display(Name = "Tình nguyện viên")]
        public virtual Volunteer Volunteer { get; set; }

        [Display(Name = "Hồ sơ sức khỏe")]
        public virtual VolunteerHealth VolunteerHealth { get; set; }
    }
}