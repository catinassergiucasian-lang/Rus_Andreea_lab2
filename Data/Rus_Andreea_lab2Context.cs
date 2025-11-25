using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rus_Andreea_lab2.Models;

namespace Rus_Andreea_lab2.Data
{
    public class Rus_Andreea_lab2Context : DbContext
    {
        public Rus_Andreea_lab2Context (DbContextOptions<Rus_Andreea_lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Rus_Andreea_lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Rus_Andreea_lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Rus_Andreea_lab2.Models.Author> Author { get; set; } = default!;
        public DbSet<Rus_Andreea_lab2.Models.Category> Category { get; set; } = default!;
        public DbSet<Rus_Andreea_lab2.Models.Member> Member { get; set; } = default!;
        public DbSet<Rus_Andreea_lab2.Models.Borrowing> Borrowing { get; set; } = default!;
    }
}
