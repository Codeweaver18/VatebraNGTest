using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Vatebra.DataAccessLayer.Entities;

namespace Vatebra.DataAccessLayer.Dbcontext
{
    public class VatebraDbContext:DbContext
    {
      

            public VatebraDbContext(DbContextOptions<VatebraDbContext> options)
                      : base(options)
            {
            Database.EnsureCreated();
            }

        public DbSet<Books> Books { get; set; }
        public DbSet<BookCopies> BoBookCopiesks { get; set; }
        public DbSet<BooksBorrowed> BooksBorrowed { get; set; }
        public DbSet<BooksBorrowed> BooBooksBorrowedks { get; set; }
        public DbSet<BookSubscriptionDetails> BookSubscriptionDetails { get; set; }
    }
}
