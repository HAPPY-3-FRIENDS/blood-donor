using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;

namespace PRN221_SE1503_GroupProject_BloodDonor_Happy3Friends.Pages.VolunteerInCampaigns
{
    public class IndexModel : PageModel
    {
        private readonly BusinessObjects.Models.PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext _context;

        public IndexModel(BusinessObjects.Models.PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext context)
        {
            _context = context;
        }

        public IList<VolunteerInCampaign> VolunteerInCampaign { get;set; }

        public async Task OnGetAsync()
        {
            VolunteerInCampaign = await _context.VolunteerInCampaigns
                .Include(v => v.Campaign)
                .Include(v => v.Volunteer)
                .Include(v => v.VolunteerHealth).ToListAsync();
        }
    }
}
