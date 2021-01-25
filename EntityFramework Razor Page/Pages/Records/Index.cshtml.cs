using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EntityFramework_Razor_Page.Models;
using EntityFramework_Razor_Page.Models.dbContext;

namespace EntityFramework_Razor_Page.Pages.Records
{
    public class IndexModel : PageModel
    {
        private readonly EntityFramework_Razor_Page.Models.dbContext.JournalDBContext _context;

        public IndexModel(EntityFramework_Razor_Page.Models.dbContext.JournalDBContext context)
        {
            _context = context;
        }

        public IList<Userr> Userr { get;set; }

        public async Task OnGetAsync()
        {
            Userr = await _context.Userrs.ToListAsync();
        }
    }
}
