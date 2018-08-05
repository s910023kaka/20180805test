using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Application.Models;

namespace _20180805.Pages.AppProfiles
{
    public class CreateModel : PageModel
    {
        private readonly Application.Models.AppSystemContext _context;

        public CreateModel(Application.Models.AppSystemContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ServerID"] = new SelectList(_context.Servers, "ServerID", "ServerID");
            return Page();
        }

        [BindProperty]
        public AppProfile AppProfile { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AppProfiles.Add(AppProfile);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}