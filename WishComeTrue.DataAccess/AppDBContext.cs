using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishComeTrue.Common.Entity;

namespace WishComeTrue.DAL
{
    public class AppDBContext: DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<WishEntity> Wishes { get; set; }
    }
}
