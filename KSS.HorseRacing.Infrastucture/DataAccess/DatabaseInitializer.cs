namespace KSS.HorseRacing.Infrastucture.DataAccess
{
    using System;
    using System.Data.Entity;

    using KSS.HorseRacing.Infrastucture.DataModels;

    public class DatabaseInitializer : DropCreateDatabaseAlways<EfContext>
    {
        protected override void Seed(EfContext context)
        {
            context.Jockeys.Add(new Jockey { DateBirth = DateTime.Now });
        }
    }
}