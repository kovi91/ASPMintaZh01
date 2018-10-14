using ASPMintaZh01.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPMintaZh01.Data
{
    public class SuperHeroContext : DbContext
    {
        public SuperHeroContext(DbContextOptions<SuperHeroContext> opt) : base(opt)
        {

        }

        public DbSet<SuperHeroModel> SuperHeroes { get; set; }
    }
}
