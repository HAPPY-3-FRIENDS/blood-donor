using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;

namespace PRN221_SE1503_GroupProject_BloodDonor_Happy3Friends.Pages.Volunteers
{
    public class IndexModel : PageModel
    {
        private readonly BusinessObjects.Models.PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext _context;

        public IndexModel(BusinessObjects.Models.PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext context)
        {
            _context = context;
        }

        public IList<Volunteer> Volunteer { get;set; }

        public async Task OnGetAsync()
        {
            Volunteer = await _context.Volunteers.ToListAsync();
        }
    }
}