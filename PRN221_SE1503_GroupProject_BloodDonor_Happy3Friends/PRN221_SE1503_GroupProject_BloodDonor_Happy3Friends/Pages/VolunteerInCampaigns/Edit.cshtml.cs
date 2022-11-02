using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Repositories.IRepositories;
using System;

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

            return Page();
        }

        public IActionResult OnPost()
        {
            if (VolunteerInCampaign.DonatedDate != null)
            {
                if (DateTime.Compare(VolunteerInCampaign.RegistrationDate, VolunteerInCampaign.DonatedDate ?? (DateTime)VolunteerInCampaign.DonatedDate) > 0)
                {
                    ModelState.AddModelError("VolunteerInCampaign.RegistrationDate", "Ngày đăng ký không được đến sau ngày tham gia hiến máu!");
                    ModelState.AddModelError("VolunteerInCampaign.DonatedDate", "Ngày tham gia hiến máu không được đến trước ngày đăng ký!");
                }
            }

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
