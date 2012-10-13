namespace KSS.HorseRacing.Infrastucture.DataAccess
{
    using System.Data.Entity;

    using KSS.HorseRacing.Infrastucture.DataModels;

    public class EfContext : DbContext
    {
        public IDbSet<Horse> Horses { get; set; }

        public IDbSet<Jockey> Jockeys { get; set; }

        public IDbSet<Race> Races { get; set; }

        public IDbSet<Participant> Participants { get; set; }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
//#if DEBUG
            Database.SetInitializer(new DatabaseInitializer());
//#endif
            //Database.SetInitializer(
            //    new MigrateDatabaseToLatestVersion<EfContext, Configuration>());

            modelBuilder.Entity<Participant>().HasMany(x => x.Races).WithMany(x => x.Participants);
        }
    }
}
