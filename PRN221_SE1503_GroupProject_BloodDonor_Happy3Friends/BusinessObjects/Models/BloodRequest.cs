using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.Models
{
    [Display(Name = "Yêu cầu máu")]
    public partial class BloodRequest
    {
        public int Id { get; set; }

        [Display(Name = "Tình nguyện viên")]
        public string VolunteerId { get; set; }

        [Required(ErrorMessage = "Tổ chức là bắt buộc!")]
        [Display(Name = "Tổ chức")]
        public int OrganizationId { get; set; }

        [Display(Name = "Ngày yêu cầu")]
        [DataType(DataType.DateTime)]
        public DateTime RequestDate { get; set; }

        [Required(ErrorMessage = "Mô tả là bắt buộc!")]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Họ và tên là bắt buộc!")]
        [Display(Name = "Họ tên người nhận")]
        public string ReceiverName { get; set; }

        [Required(ErrorMessage = "Số CMND/CCCD/Hộ Chiếu là bắt buộc!")]
        [Display(Name = "Số CMND/CCCD/Hộ chiếu người nhận")]
        public string ReceiverIdentityNumber { get; set; }

        [Display(Name = "Số điện thoại người nhận")]
        [Required(ErrorMessage = "Số điện thoại là bắt buộc!")]
        [RegularExpression(@"(0[3|5|7|8|9])+([0-9]{8})\b", ErrorMessage = "Số điện thoại không hợp lệ!")]
        public string ReceiverPhone { get; set; }

        [Display(Name = "Trạng thái")]
        public string Status { get; set; }

        public virtual Organization Organization { get; set; }
        public virtual Volunteer Volunteer { get; set; }
    }
}
