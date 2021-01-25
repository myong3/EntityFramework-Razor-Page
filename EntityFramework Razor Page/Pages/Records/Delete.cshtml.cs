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
    public class DeleteModel : PageModel
    {
        private readonly EntityFramework_Razor_Page.Models.dbContext.JournalDBContext _context;

        public DeleteModel(EntityFramework_Razor_Page.Models.dbContext.JournalDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Userr Userr { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Userr = await _context.Userrs.FirstOrDefaultAsync(m => m.userId == id);

            if (Userr == null)
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

            Userr = await _context.Userrs.FindAsync(id);

            if (Userr != null)
            {
                _context.Userrs.Remove(Userr);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
