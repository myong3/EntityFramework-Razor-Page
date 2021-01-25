using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EntityFramework_Razor_Page.Models;
using EntityFramework_Razor_Page.Models.dbContext;

namespace EntityFramework_Razor_Page.Pages.Records
{
    public class CreateModel : PageModel
    {
        private readonly EntityFramework_Razor_Page.Models.dbContext.JournalDBContext _context;

        public CreateModel(EntityFramework_Razor_Page.Models.dbContext.JournalDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Userr Userr { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Userrs.Add(Userr);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
