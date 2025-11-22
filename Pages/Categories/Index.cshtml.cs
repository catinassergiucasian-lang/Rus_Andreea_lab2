using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Rus_Andreea_lab2.Data;
using Rus_Andreea_lab2.Models;
using Rus_Andreea_lab2.Models.ViewModels;
using Rus_Andreea_lab2.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Rus_Andreea_lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Rus_Andreea_lab2Context _context;

        public IndexModel(Rus_Andreea_lab2Context context)
        {
            _context = context;
        }

        public CategoryIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id)
        {
            CategoryData = new CategoryIndexData();

            CategoryData.Categories = await _context.Category
                .Include(c => c.BookCategories)
                    .ThenInclude(bc => bc.Book)
                        .ThenInclude(b => b.Author)
                .OrderBy(c => c.CategoryName)
                .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;
                var category = CategoryData.Categories
                    .Where(c => c.ID == id.Value)
                    .Single();

                CategoryData.Books = category.BookCategories
                    .Select(bc => bc.Book)
                    .ToList();
            }
        }
    }
}
