namespace OnBoarding.EntityContext.Migrations
{
    using OnBoarding.Entities;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<OnBoarding.EntityContext.OnBoardingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OnBoarding.EntityContext.OnBoardingContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Set<Policy>().AddOrUpdate(
             new Policy
             {
                 Code = "POLICY001",
                 CreatedOn = DateTime.Now.AddDays(-100),
                 Id = Guid.NewGuid(),
                 IsActive = true,
                 MaturityDate = DateTime.Now.AddDays(-100),
                 PolicyBenifit = 500000,
                 PolicyId = 12345678,
                 Premium = 5000
             },
              new Policy
              {
                  Code = "POLICY002",
                  CreatedOn = DateTime.Now.AddDays(-50),
                  Id = Guid.NewGuid(),
                  IsActive = true,
                  MaturityDate = DateTime.Now.AddDays(-50),
                  PolicyBenifit = 400000,
                  PolicyId = 22345678,
                  Premium = 4000
              }
            );

        }
    }
}
