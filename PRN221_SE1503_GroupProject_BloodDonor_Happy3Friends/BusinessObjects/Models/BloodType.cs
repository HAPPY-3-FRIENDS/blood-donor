using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.Models
{
    public enum BloodType
    {
        [Display(Name = "A")]
        A,
        [Display(Name = "B")]
        B,
        [Display(Name = "AB")]
        AB,
        [Display(Name = "O")]
        O,
        [Display(Name = "Chưa xác định")]
        UNDEFINED,
    }
}