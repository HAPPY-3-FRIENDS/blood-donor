using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;

namespace PRN221_SE1503_GroupProject_BloodDonor_Happy3Friends.Pages.Campaigns
{
    public class IndexModel : PageModel
    {
        private readonly BusinessObjects.Models.BloodDonorContext _context;

        public IndexModel(BusinessObjects.Models.BloodDonorContext context)
        {
            _context = context;
        }

        public IList<Campaign> Campaign { get;set; }

        public async Task OnGetAsync()
        {
            Campaign = await _context.Campaigns
                .Include(c => c.Organization).ToListAsync();
        }
    }
}
