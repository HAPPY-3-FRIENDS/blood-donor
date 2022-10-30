using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.Models
{
    [Display(Name = "Tổ chức")]
    public partial class Organization
    {
        public Organization()
        {
            BloodRequests = new HashSet<BloodRequest>();
            Campaigns = new HashSet<Campaign>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Tên đăng nhập là bắt buộc!")]
        [Display(Name = "Tên đăng nhập")]
        [RegularExpression(@"^[a-zA-Z0-9_-]{8,20}$", ErrorMessage = "Tên đăng nhập chỉ có thể bao gồm chữ cái, _ và - có độ dài từ 8 đến 20 ký tự!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mật khẩu là bắt buộc!")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "Tối thiểu tám ký tự, ít nhất một chữ hoa, một chữ thường và một số!")]
        [StringLength(16, ErrorMessage = "Mật khẩu không dài hơn 16 ký tự!")]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Tên tổ chức là bắt buộc!")]
        [Display(Name = "Tên tổ chức")]
        public string Name { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Display(Name = "Địa chỉ")]
        public string AddressDetails { get; set; }

        [Required(ErrorMessage = "Quận, Huyện, Thành phố là bắt buộc!")]
        [Display(Name = "Quận, Huyện, Thành phố")]
        public string District { get; set; }

        [Required(ErrorMessage = "Tỉnh, Thành phố là bắt buộc")]
        [Display(Name = "Tỉnh, Thành phố")]
        public string City { get; set; }

        [Display(Name = "Hội chữ thập đỏ")]
        public bool IsRedCross { get; set; }

        public virtual ICollection<BloodRequest> BloodRequests { get; set; }
        public virtual ICollection<Campaign> Campaigns { get; set; }
    }
}
