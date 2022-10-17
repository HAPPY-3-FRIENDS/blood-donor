using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;

namespace PRN221_SE1503_GroupProject_BloodDonor_Happy3Friends.Pages.Campaigns
{
    public class CreateModel : PageModel
    {
        private readonly BusinessObjects.Models.BloodDonorContext _context;

        public CreateModel(BusinessObjects.Models.BloodDonorContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["OrganizationId"] = new SelectList(_context.Organizations, "Id", "City");
            return Page();
        }

        [BindProperty]
        public Campaign Campaign { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Campaigns.Add(Campaign);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
