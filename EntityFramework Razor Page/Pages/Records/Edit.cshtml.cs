using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EntityFramework_Razor_Page.Models;
using EntityFramework_Razor_Page.Models.dbContext;

namespace EntityFramework_Razor_Page.Pages.Records
{
    public class EditModel : PageModel
    {
        private readonly EntityFramework_Razor_Page.Models.dbContext.JournalDBContext _context;

        public EditModel(EntityFramework_Razor_Page.Models.dbContext.JournalDBContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Userr).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserrExists(Userr.userId))
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

        private bool UserrExists(int id)
        {
            return _context.Userrs.Any(e => e.userId == id);
        }
    }
}
