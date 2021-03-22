using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWEB.Models
{
    public class LibraryContext : DbContext
    {
        public DbSet<Page> Pages { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options) {}
    }
}
