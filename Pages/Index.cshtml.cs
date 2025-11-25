using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Rus_Andreea_lab2.Data;
using Rus_Andreea_lab2.Models;

namespace Rus_Andreea_lab2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Rus_Andreea_lab2.Data.Rus_Andreea_lab2Context _context;

        public IndexModel(Rus_Andreea_lab2.Data.Rus_Andreea_lab2Context context)
        {
            _context = context;
        }

        public IList<Member> Member { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Member = await _context.Member.ToListAsync();
        }
    }
}
