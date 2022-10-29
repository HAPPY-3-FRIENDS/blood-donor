using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Repositories.IRepositories;

namespace PRN221_SE1503_GroupProject_BloodDonor_Happy3Friends.Pages.VolunteerInCampaigns
{
    public class EditModel : PageModel
    {
        private readonly PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext _context;
        private readonly IVolunteerInCampaignRepository _volunteerInCampaignRepository;

        public EditModel(PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext context, IVolunteerInCampaignRepository volunteerInCampaignRepository)
        {
            _context = context;
            _volunteerInCampaignRepository = volunteerInCampaignRepository;
        }

        [BindProperty]
        public VolunteerInCampaign VolunteerInCampaign { get; set; }

        public IActionResult OnGet(int id)
        {
            VolunteerInCampaign = _volunteerInCampaignRepository.GetVolunteerInCampaignById(id);

            if (VolunteerInCampaign == null)
            {
                return NotFound();
            }

            ViewData["CampaignId"] = new SelectList(_context.Campaigns, "Id", "Name");
            ViewData["VolunteerId"] = new SelectList(_context.Volunteers, "Phone", "Name");
            ViewData["VolunteerHealthId"] = new SelectList(_context.VolunteerHealths, "Id", "Id");
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _volunteerInCampaignRepository.UpdateVolunteerInCampaign(VolunteerInCampaign);
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

            return RedirectToPage("/VolunteerInCampaigns/Index", new
            {
                campaignId = VolunteerInCampaign.CampaignId
            });
        }

        private bool VolunteerInCampaignExists(int id)
        {
            return _volunteerInCampaignRepository.GetVolunteerInCampaignById(id) != null;
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
    }
}
