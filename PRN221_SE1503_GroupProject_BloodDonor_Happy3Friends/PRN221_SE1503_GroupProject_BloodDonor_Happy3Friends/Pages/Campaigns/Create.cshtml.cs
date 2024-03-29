﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using Repositories.IRepositories;
using System;

namespace PRN221_SE1503_GroupProject_BloodDonor_Happy3Friends.Pages.Campaigns
{
    public class CreateModel : PageModel
    {
        private readonly ICampaignRepository _campaignRepository;
        private readonly IOrganizationRepository _organizationRepository;

        public CreateModel(ICampaignRepository campaignRepository, IOrganizationRepository organizationRepository)
        {
            _campaignRepository = campaignRepository;
            _organizationRepository = organizationRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Campaign Campaign { get; set; }

        public IActionResult OnPost()
        {
            if (DateTime.Compare(Campaign.StartDate, DateTime.Now) < 0)
            {
                ModelState.AddModelError("Campaign.StartDate", "Ngày bắt đầu không được sớm hơn ngày hiện tại!");
            }

            if (DateTime.Compare(Campaign.StartDate, Campaign.EndDate) > 0)
            {
                ModelState.AddModelError("Campaign.StartDate", "Ngày bắt đầu không được đến sau ngày kết thúc!");
                ModelState.AddModelError("Campaign.EndDate", "Ngày kết thúc không được đến trước ngày bắt đầu!");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _campaignRepository.CreateCampaign(Campaign);

            return RedirectToPage("./Index");
        }

        public IActionResult OnPostDelete(int itemId)
        {
            try
            {
                _campaignRepository.DeleteCampaignById(itemId);
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