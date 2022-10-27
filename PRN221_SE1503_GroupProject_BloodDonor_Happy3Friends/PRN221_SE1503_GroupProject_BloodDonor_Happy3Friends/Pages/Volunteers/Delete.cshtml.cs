using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;

namespace PRN221_SE1503_GroupProject_BloodDonor_Happy3Friends.Pages.Volunteers
{
    public class DeleteModel : PageModel
    {
        private readonly PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext _context;

        public DeleteModel(PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Volunteer Volunteer { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Volunteer = await _context.Volunteers.FirstOrDefaultAsync(m => m.Phone == id);

            if (Volunteer == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Volunteer = await _context.Volunteers.FindAsync(id);

            if (Volunteer != null)
            {
                _context.Volunteers.Remove(Volunteer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}