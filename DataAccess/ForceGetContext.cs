using DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ForceGetContext : DbContext
    {
        public ForceGetContext(DbContextOptions<ForceGetContext> options) : base(options) { }
        public DbSet<Offer> Offer { get; set; }

    }
}
