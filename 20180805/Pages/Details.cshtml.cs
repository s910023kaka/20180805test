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
    public class DetailsModel : PageModel
    {
        private readonly Application.Models.AppSystemContext _context;

        public DetailsModel(Application.Models.AppSystemContext context)
        {
            _context = context;
        }

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
    }
}
