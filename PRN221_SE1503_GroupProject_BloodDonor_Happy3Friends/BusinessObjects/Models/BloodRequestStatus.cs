using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.Models
{
    public enum BloodRequestStatus
    {
        [Display(Name = "Đã yêu cầu")]
        NEW,
        [Display(Name = "Đã chấp nhận")]
        ACCEPTED,
        [Display(Name = "Đã từ chối")]
        REJECTED,
        [Display(Name = "Đã hủy")]
        CANCEL
    }
}
