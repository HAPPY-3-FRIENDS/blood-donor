using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;

namespace PRN221_SE1503_GroupProject_BloodDonor_Happy3Friends.Pages.VolunteerInCampaigns
{
    public class EditModel : PageModel
    {
        private readonly BusinessObjects.Models.PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext _context;

        public EditModel(BusinessObjects.Models.PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext context)
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
           ViewData["CampaignId"] = new SelectList(_context.Campaigns, "Id", "BloodTypeRequired");
           ViewData["VolunteerId"] = new SelectList(_context.Volunteers, "Phone", "Phone");
           ViewData["VolunteerHealthId"] = new SelectList(_context.VolunteerHealths, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(VolunteerInCampaign).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VolunteerInCampaignExists(VolunteerInCampaign.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool VolunteerInCampaignExists(int id)
        {
            return _context.VolunteerInCampaigns.Any(e => e.Id == id);
        }
    }
}
