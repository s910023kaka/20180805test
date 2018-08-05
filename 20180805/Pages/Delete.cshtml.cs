using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Application.Models;

namespace _20180805.Pages.AppProfiles
{
    public class DeleteModel : PageModel
    {
        private readonly Application.Models.AppSystemContext _context;

        public DeleteModel(Application.Models.AppSystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AppProfile AppProfile { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AppProfile = await _context.AppProfiles
                .Include(a => a.Server).FirstOrDefaultAsync(m => m.AppProfileID == id);

            if (AppProfile == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AppProfile = await _context.AppProfiles.FindAsync(id);

            if (AppProfile != null)
            {
                _context.AppProfiles.Remove(AppProfile);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
