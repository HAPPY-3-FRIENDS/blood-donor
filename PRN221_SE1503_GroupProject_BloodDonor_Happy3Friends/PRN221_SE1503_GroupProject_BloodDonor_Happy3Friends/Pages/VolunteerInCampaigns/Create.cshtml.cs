using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;

namespace PRN221_SE1503_GroupProject_BloodDonor_Happy3Friends.Pages.VolunteerInCampaigns
{
    public class CreateModel : PageModel
    {
        private readonly BusinessObjects.Models.PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext _context;

        public CreateModel(BusinessObjects.Models.PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CampaignId"] = new SelectList(_context.Campaigns, "Id", "BloodTypeRequired");
        ViewData["VolunteerId"] = new SelectList(_context.Volunteers, "Phone", "Phone");
        ViewData["VolunteerHealthId"] = new SelectList(_context.VolunteerHealths, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public VolunteerInCampaign VolunteerInCampaign { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.VolunteerInCampaigns.Add(VolunteerInCampaign);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
    }
}
