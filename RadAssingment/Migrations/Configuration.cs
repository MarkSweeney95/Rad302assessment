namespace RadAssingment.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RadAssingment.Models.BossContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(RadAssingment.Models.BossContext context)
        {
            var bosses = new List<BossClass>
            {
                new BossClass() {imageURL="~/Content/Images/Taurus_Demon.png",Name="Taurus Demon",Location="Undead Burg",Health=1215,Weaknesses="None",Resistences="Fire and magic",SoulsGiven=3000},
                new BossClass() {imageURL="~/Content/Images/Sif.png",Name="Great Wolf Sif",Location="Grave Of Artorias",Health=3420,Weaknesses="None",Resistences="Fire and lighting",SoulsGiven=40000},
                new BossClass() {imageURL="~/Content/Images/Capra_Demon_Render.png",Name="Capra Demon",Location="Undead Depths",Health=1176,Weaknesses="None",Resistences="Fire and magic",SoulsGiven=6000},
                new BossClass() {imageURL="~/Content/Images/Dark Souls - Artorias 3.jpg",Name="Artorias The Aybsswalker",Location="Oolacile Township",Health=3750,Weaknesses="None",Resistences="Posin,Toxic and Bleed",SoulsGiven=50000},
                new BossClass() {imageURL="~/Content/Images/OrnsteinandSmough.png",Name="Orinstein & Smaug",Location="Anor Londo",Health=4228,Weaknesses="None",Resistences="Fire and magic",SoulsGiven=50000},                
            };

            bosses.ForEach(i => context.Bosses.Add(i));

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
