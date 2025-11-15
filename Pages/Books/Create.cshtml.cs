using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rus_Andreea_lab2.Data;
using Rus_Andreea_lab2.Models;

namespace Rus_Andreea_lab2.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly Rus_Andreea_lab2.Data.Rus_Andreea_lab2Context _context;

        public CreateModel(Rus_Andreea_lab2.Data.Rus_Andreea_lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");

            var authors = _context.Set<Author>()
                .Select(a => new {
                    a.ID,
                    FullName = a.FirstName + " " + a.LastName
                })
                .ToList();
            ViewData["AuthorID"] = new SelectList(authors, "ID", "FullName");

            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Book.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
