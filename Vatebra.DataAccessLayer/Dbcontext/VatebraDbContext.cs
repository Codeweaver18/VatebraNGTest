using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace Vatebra.DataAccessLayer.Dbcontext
{
    public class VatebraDbContext:DbContext
    {
      

            public VatebraDbContext(DbContextOptions<VatebraDbContext> options)
                      : base(options)
            {
                Database.Migrate();
            }
         

        }
    }
