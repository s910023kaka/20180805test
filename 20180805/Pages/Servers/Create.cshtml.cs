using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Application.Models;

namespace _20180805.Pages.Servers
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
            return Page();
        }

        [BindProperty]
        public Server Server { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Servers.Add(Server);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}