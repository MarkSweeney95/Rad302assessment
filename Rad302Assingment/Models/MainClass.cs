using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Rad302Assingment.Models
{
    public enum TitleClass
    {
        Picture,
        Name,
        Location,
        Health,
        Weakness,
        Resistence,
        Game
    }
    public class Class
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Bosses> Bosses { get; set; }
    }

    public class Bosses
    {
        public int ID { get; set; }

        public string name { get; set; }
        public string location { get; set; }
        public string weakness { get; set; }
        public double health { get; set; }
        public string resistences { get; set; }
        public string GameName { get; set;}
        

       

    }
    public class BossContext : DbContext
    {
        public DbSet<Bosses> Bosses { get; set; }
        public DbSet<Class> Classes { get; set; }

        public BossContext()
            :base("BossConection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
    }

}