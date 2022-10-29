using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;

namespace PRN221_SE1503_GroupProject_BloodDonor_Happy3Friends.Pages.VolunteerInCampaigns
{
    public class DeleteModel : PageModel
    {
        private readonly BusinessObjects.Models.PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext _context;

        public DeleteModel(BusinessObjects.Models.PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public VolunteerInCampaign VolunteerInCampaign { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VolunteerInCampaign = await _context.VolunteerInCampaigns
                .Include(v => v.Campaign)
                .Include(v => v.Volunteer)
                .Include(v => v.VolunteerHealth).FirstOrDefaultAsync(m => m.Id == id);

            if (VolunteerInCampaign == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VolunteerInCampaign = await _context.VolunteerInCampaigns.FindAsync(id);

            if (VolunteerInCampaign != null)
            {
                _context.VolunteerInCampaigns.Remove(VolunteerInCampaign);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
