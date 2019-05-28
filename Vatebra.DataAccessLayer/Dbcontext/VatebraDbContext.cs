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
            Database.Migrate();
            }

        public DbSet<Books> Books { get; set; }
        public DbSet<BookCopies> BookCopies { get; set; }
        public DbSet<BooksBorrowed> BooksBorrowed { get; set; }
        public DbSet<BooksBorrowed> BooksBorrowedks { get; set; }
        public DbSet<BookSubscriptionDetails> BookSubscriptionDetails { get; set; }
        public DbSet<Match> Match { get; set; }
        public DbSet<MatchGoals> MatchGoals { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<Footballers> Footballers { get; set; }
    }
}
