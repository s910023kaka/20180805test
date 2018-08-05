using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Application.Models;

namespace _20180805.Pages.Servers
{
    public class DeleteModel : PageModel
    {
        private readonly Application.Models.AppSystemContext _context;

        public DeleteModel(Application.Models.AppSystemContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Server = await _context.Servers.FindAsync(id);

            if (Server != null)
            {
                _context.Servers.Remove(Server);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
