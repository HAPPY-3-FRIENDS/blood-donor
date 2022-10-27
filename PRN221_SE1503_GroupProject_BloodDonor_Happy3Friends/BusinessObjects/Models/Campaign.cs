using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.Models
{
    public partial class Campaign
    {
        public Campaign()
        {
            VolunteerInCampaigns = new HashSet<VolunteerInCampaign>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Tên chiến dịch là bắt buộc!")]
        [Display(Name = "Tên chiến dịch")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Mô tả cho chiến dịch là bắt buộc!")]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Nhóm máu của chiến dịch là bắt buộc")]
        [Display(Name = "Nhóm máu yêu cầu")]
        public string BloodTypeRequired { get; set; }

        [Display(Name = "Địa chỉ")]
        public string AddressDetails { get; set; }

        [Required(ErrorMessage = "Quận, Huyện, Thành phố là bắt buộc!")]
        [Display(Name = "Quận, Huyện, Thành phố")]
        public string District { get; set; }

        [Required(ErrorMessage = "Tỉnh, Thành phố là bắt buộc")]
        [Display(Name = "Tỉnh, Thành phố")]
        public string City { get; set; }

        [Required(ErrorMessage = "Ngày bắt đầu của chiến dịch là bắt buộc")]
        [Display(Name = "Ngày bắt đầu")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Ngày kết thúc chiến dịch là bắt buộc")]
        [Display(Name = "Ngày kết thúc")]
        public DateTime EndDate { get; set; }

        public int OrganizationId { get; set; }

        public virtual Organization Organization { get; set; }
        public virtual ICollection<VolunteerInCampaign> VolunteerInCampaigns { get; set; }
    }
}
