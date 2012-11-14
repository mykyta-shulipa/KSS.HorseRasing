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

        public IDbSet<Racer> Racers { get; set; }

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        /// before the model has been locked down and used to initialize the context.  The default
        /// implementation of this method does nothing, but it can be overridden in a derived class
        /// such that the model can be further configured before it is locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        /// <remarks>
        /// Typically, this method is called only once when the first instance of a derived context
        /// is created.  The model for that context is then cached and is for all further instances of
        /// the context in the app domain.  This caching can be disabled by setting the ModelCaching
        /// property on the given ModelBuidler, but note that this can seriously degrade performance.
        /// More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        /// classes directly.
        /// </remarks>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //#if DEBUG
            Database.SetInitializer(new DatabaseInitializer());
            //#endif
            //Database.SetInitializer(
            //    new MigrateDatabaseToLatestVersion<EfContext, Configuration>());
        }
    }
}
