using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RadAssingment.Models
{
    public class BossClass
    {
        public int ID { get; set; }

        public string imageURL { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public double Health { get; set; }
        public string Resistences { get; set; }
        public string Weaknesses { get; set; }
        public int SoulsGiven { get; set; }
    }
    public class BossContext : DbContext
    {
        public DbSet<BossClass> Bosses { get; set; }
       

        public BossContext()
            : base("BossConection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
    }
}