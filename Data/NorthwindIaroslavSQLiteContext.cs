using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NorthwindIaroslav.Models;

namespace Northwindiaroslav.Data
{
    public class NorthwindIaroslavSQLiteContext : DbContext
    {
        public NorthwindIaroslavSQLiteContext (DbContextOptions<NorthwindIaroslavSQLiteContext> options)
            : base(options)
        {
        }

        public DbSet<NorthwindIaroslav.Models.Category> Categories { get; set; } = default!;
    }
}
