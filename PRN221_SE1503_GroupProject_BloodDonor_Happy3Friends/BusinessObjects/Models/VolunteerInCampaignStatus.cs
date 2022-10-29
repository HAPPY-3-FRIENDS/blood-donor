using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.Models
{
    public enum VolunteerInCampaignStatus
    {
        [Display(Name = "Đã đăng ký")]
        NEW,
        [Display(Name = "Đã tham gia")]
        JOINED,
        [Display(Name = "Hủy đăng ký")]
        CANCEL,
        [Display(Name = "Quá hạn đăng ký")]
        OVERDUE,
    }
}