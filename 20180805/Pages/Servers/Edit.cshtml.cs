using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Application.Models;

namespace _20180805.Pages.Servers
{
    public class EditModel : PageModel
    {
        private readonly Application.Models.AppSystemContext _context;

        public EditModel(Application.Models.AppSystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Server Server { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Server = await _context.Servers.FirstOrDefaultAsync(m => m.ServerID == id);

            if (Server == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Server).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServerExists(Server.ServerID))
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

        private bool ServerExists(int id)
        {
            return _context.Servers.Any(e => e.ServerID == id);
        }
    }
}
