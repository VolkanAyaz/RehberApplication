using JetBrains.Annotations;
using KisilerManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KisilerManagement.Model
{
    public class KisilerDbContext : DbContext
    {
        
        public KisilerDbContext(DbContextOptions<KisilerDbContext> options) : base(options)
        {
        }

        public DbSet<Kisiler> Kisiler { get; set; }
        public DbSet<IletisimBilgileri> IletisimBilgileri { get; set; }
        public DbSet<BilgiTipleri> BilgiTipleri { get; set; }
    }
}
