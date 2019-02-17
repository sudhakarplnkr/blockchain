namespace OnBoarding.EntityContext
{
    using Entities;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class OnBoardingContext : DbContext
    {
        public OnBoardingContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer<OnBoardingContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Policy>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
