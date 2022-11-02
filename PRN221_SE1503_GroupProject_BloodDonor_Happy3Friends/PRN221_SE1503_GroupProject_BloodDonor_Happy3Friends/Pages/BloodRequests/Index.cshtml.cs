using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using Repositories.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using System;

namespace PRN221_SE1503_GroupProject_BloodDonor_Happy3Friends.Pages.BloodRequests
{
    public class IndexModel : PageModel
    {
        private readonly IBloodRequestRepository _bloodRequestRepository;

        public IndexModel(IBloodRequestRepository bloodRequestRepository)
        {
            _bloodRequestRepository = bloodRequestRepository;
        }

        public IList<BloodRequest> BloodRequests { get;set; }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("role") == null)
            {
                HttpContext.Session.SetString("action", "BloodRequest");
                return RedirectToPage("/Login");
            }
            if (HttpContext.Session.GetString("role") != null && HttpContext.Session.GetString("role") == "Volunteer")
            {
                BloodRequests = _bloodRequestRepository.GetBloodRequestsByVolunteerPhone(HttpContext.Session.GetString("phone"));
            } 
            if (HttpContext.Session.GetString("role") != null && HttpContext.Session.GetString("role") == "Organization")
            {
                BloodRequests = _bloodRequestRepository.GetBloodRequestsByOrganizationId(int.Parse(HttpContext.Session.GetString("phone")));
            }

            return Page();
        }

        public IActionResult OnPostDelete(int itemId)
        {
            try
            {
                _bloodRequestRepository.DeleteBloodRequest(itemId);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToPage("./Index");
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
    }
}
