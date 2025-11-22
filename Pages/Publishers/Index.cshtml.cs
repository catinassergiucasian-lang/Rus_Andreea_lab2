using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Rus_Andreea_lab2.Models;
using Rus_Andreea_lab2.Data;
using Rus_Andreea_lab2.ViewModels;


namespace Rus_Andreea_lab2.Pages.Publishers
{
    public class IndexModel : PageModel
    {
        private readonly Rus_Andreea_lab2.Data.Rus_Andreea_lab2Context _context;

        public IndexModel(Rus_Andreea_lab2.Data.Rus_Andreea_lab2Context context)
        {
            _context = context;
        }

        public IList<Publisher> Publisher { get; set; } = default!;
        public PublisherIndexData PublisherData { get; set; }
        public int PublisherID { get; set; }
        public int BookID { get; set; }
        public async Task OnGetAsync(int? id, int? bookID)
        {
            PublisherData = new PublisherIndexData();
            PublisherData.Publishers = await _context.Publisher
            .Include(i => i.Books)
            .ThenInclude(c => c.Author)
            .OrderBy(i => i.PublisherName)
            .ToListAsync();
            if (id != null)
            {
                PublisherID = id.Value;
                Publisher publisher = PublisherData.Publishers
                .Where(i => i.ID == id.Value).Single();
                PublisherData.Books = publisher.Books.ToList();
            }
        }
    }
}
