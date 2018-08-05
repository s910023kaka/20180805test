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
    public class IndexModel : PageModel
    {
        private readonly Application.Models.AppSystemContext _context;

        public IndexModel(Application.Models.AppSystemContext context)
        {
            _context = context;
        }

        public IList<AppProfile> AppProfile { get;set; }

        public async Task OnGetAsync()
        {
            AppProfile = await _context.AppProfiles
                .Include(a => a.Server).ToListAsync();
        }
    }
}
