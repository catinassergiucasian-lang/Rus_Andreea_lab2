using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Rus_Andreea_lab2.Data;
using Rus_Andreea_lab2.Models;

namespace Rus_Andreea_lab2.Pages.Borrowings
{
    public class DetailsModel : PageModel
    {
        private readonly Rus_Andreea_lab2.Data.Rus_Andreea_lab2Context _context;

        public DetailsModel(Rus_Andreea_lab2.Data.Rus_Andreea_lab2Context context)
        {
            _context = context;
        }

        public Borrowing Borrowing { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Borrowing = await _context.Borrowing
            .Include(b => b.Member)
            .Include(b => b.Book)
                .ThenInclude(b => b.Author)
            .FirstOrDefaultAsync(m => m.ID == id);

            if (Borrowing == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
