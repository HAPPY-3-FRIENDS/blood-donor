using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Models
{
    public enum BloodAmount : int
    {
        [Display(Name = "250ml")]
        ML_250 = 250,
        [Display(Name = "350ml")]
        ML_350 = 350,
        [Display(Name = "450ml")]
        ML_450 = 450
    }
}
