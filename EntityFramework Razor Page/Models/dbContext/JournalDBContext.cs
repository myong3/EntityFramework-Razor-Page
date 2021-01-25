using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework_Razor_Page.Models.dbContext
{
    public class JournalDBContext : DbContext
    {
        public DbSet<Userr> Userrs { get; set; }

        public JournalDBContext(DbContextOptions options) : base(options)
        {

        }

        //REF: https://blog.darkthread.net/blog/ef-core-notes-2/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //建立日期 Unique Index
            modelBuilder.Entity<Userr>()
                .HasIndex(o => o.userId).IsUnique();
        }
    }
}
