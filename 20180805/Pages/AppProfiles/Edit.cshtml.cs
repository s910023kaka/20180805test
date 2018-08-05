using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Application.Models;

namespace _20180805.Pages.AppProfiles
{
    public class EditModel : PageModel
    {
        private readonly Application.Models.AppSystemContext _context;

        public EditModel(Application.Models.AppSystemContext context)
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
           ViewData["ServerID"] = new SelectList(_context.Servers, "ServerID", "ServerID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(AppProfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppProfileExists(AppProfile.AppProfileID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AppProfileExists(int id)
        {
            return _context.AppProfiles.Any(e => e.AppProfileID == id);
        }
    }
}
