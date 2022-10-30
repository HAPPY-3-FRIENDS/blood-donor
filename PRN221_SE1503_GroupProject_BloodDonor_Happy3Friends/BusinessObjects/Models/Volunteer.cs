using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.Models
{
    [Display(Name = "Tình nguyện viên")]
    public partial class Volunteer
    {
        public Volunteer()
        {
            BloodRequests = new HashSet<BloodRequest>();
            VolunteerInCampaigns = new HashSet<VolunteerInCampaign>();
        }

        [Required(ErrorMessage = "Số điện thoại là bắt buộc!")]
        [Display(Name = "Số điện thoại")]
        [RegularExpression(@"(0[3|5|7|8|9])+([0-9]{8})\b", ErrorMessage = "Số điện thoại không hợp lệ!")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Họ và tên là bắt buộc!")]
        [Display(Name = "Họ và tên")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Số CMND/CCCD/Hộ Chiếu là bắt buộc!")]
        [Display(Name = "Số CMND/CCCD/Hộ Chiếu")]
        public string IdentityNumber { get; set; }

        [Required(ErrorMessage = "Mật khẩu là bắt buộc!")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "Tối thiểu tám ký tự, ít nhất một chữ hoa, một chữ thường và một số")]
        [StringLength(16, ErrorMessage = "Mật khẩu không dài hơn 16 ký tự!")]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [RegularExpression(@"^[a-z][a-z0-9_\.]{5,32}@[a-z0-9]{2,}(\.[a-z0-9]{2,4}){1,2}$", ErrorMessage = "Địa chỉ email không hợp lệ!")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ngày sinh là bắt buộc!\nNếu không có ngày sinh thì chọn mặc định là ngày 01 tháng 01!")]
        [DataType(DataType.Date)]
        [Display(Name = "Ngày sinh")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Địa chỉ")]
        public string AddressDetails { get; set; }

        [Required(ErrorMessage = "Quận, Huyện, Thành phố là bắt buộc!")]
        [Display(Name = "Quận, Huyện, Thành phố")]
        public string District { get; set; }

        [Required(ErrorMessage = "Tỉnh, Thành phố là bắt buộc!")]
        [Display(Name = "Tỉnh, Thành phố")]
        public string City { get; set; }

        [Required(ErrorMessage = "Nhóm máu là bắt buộc!")]
        [Display(Name = "Nhóm máu")]
        public string BloodType { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Lần hiến máu gần nhất")]
        public DateTime? LastDonatedDate { get; set; }

        public virtual ICollection<BloodRequest> BloodRequests { get; set; }
        public virtual ICollection<VolunteerInCampaign> VolunteerInCampaigns { get; set; }
    }
}