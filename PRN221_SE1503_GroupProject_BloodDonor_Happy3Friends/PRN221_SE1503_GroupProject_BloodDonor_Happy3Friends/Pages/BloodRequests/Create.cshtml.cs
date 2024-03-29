﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using Repositories.IRepositories;
using Microsoft.AspNetCore.Http;

namespace PRN221_SE1503_GroupProject_BloodDonor_Happy3Friends.Pages.BloodRequests
{
    public class CreateModel : PageModel
    {
        private readonly IBloodRequestRepository _bloodRequestRepository;
        private readonly IOrganizationRepository _organizationRepository;

        public CreateModel(IBloodRequestRepository bloodRequestRepository, IOrganizationRepository organizationRepository)
        {
            _bloodRequestRepository = bloodRequestRepository;
            _organizationRepository = organizationRepository;
        }

        public IActionResult OnGet()
        {
            ViewData["OrganizationId"] = new SelectList(_organizationRepository.GetOrganizations(), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public BloodRequest BloodRequest { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                string volunteerId = HttpContext.Session.GetString("phone");

                BloodRequest.VolunteerId = volunteerId;

                _bloodRequestRepository.CreateBloodRequest(BloodRequest);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return Page();
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
