namespace CineRating.Migrations {
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CineRating.Models.CineRatingDb> {
        public Configuration() {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CineRating.Models.CineRatingDb context) {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}