namespace Rad302Assingment.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Rad302Assingment.Models.BossContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Rad302Assingment.Models.BossContext context)
        {
            List<Class> classes = new List<Class>()
            {
                new Class {Name = "Dark Souls" },
                new Class {Name = "Dark Souls 2" }
            };

            classes.ForEach(C => context.Classes.Add(C));

            List<Bosses> Bosses = new List<Bosses>()
            {
                new Bosses {ID=1,name = "Taurus Demon",location="Undead Burg",weakness="Fire and Lighting",health=1215,resistences="None", GameName="Dark Souls "},
            };
            Bosses.ForEach(b => context.Bosses.Add(b));
            context.SaveChanges();
        }
    }
}
