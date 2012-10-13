namespace KSS.HorseRacing.Infrastucture.DataAccess
{
    using System;
    using System.Data.Entity;

    using KSS.HorseRacing.Infrastucture.DataModels;

    public class DatabaseInitializer : DropCreateDatabaseAlways<EfContext>
    {
        protected override void Seed(EfContext context)
        {
            addJockeys(context);

            addHorses(context);

            addRoles(context);

            
        }

        private void addRoles(EfContext context)
        {
            context.Roles.Add(new Role { Name = "admin" });
            context.Roles.Add(new Role { Name = "user" });
            context.Roles.Add(new Role { Name = "judge" });
        }

        private void addJockeys(EfContext context)
        {
            addOneJockey(context, "Hero", "Alexandr", "Sergeevich", "Tvidov", "01-02-1979");
            addOneJockey(context, "Moonlight", "Maria", "Olegovna", "Kurilo", "26-04-1990");
            addOneJockey(context, "Warrior", "Nikolay", "Mikhailovitch", "Ivanov", "21-02-1988");
            addOneJockey(context, "Stone", "Eugeniy", "Alexandrovich", "Seleznev", "27-10-1987");

        }

        private void addHorses(EfContext context)
        {
            addOneHorse(context, "Lucky");
        }

        private void addOneHorse(EfContext context, string nickname, string datetime)
        {
            context.Horses.Add(new Horse { DateBirth = DateTime.Parse(datetime), Nickname = nickname });
        }

        private void addOneHorse(EfContext context, string nickname)
        {
            var years = new Random().Next(1, 7);
            context.Horses.Add(new Horse { DateBirth = DateTime.Now.AddYears(-years), Nickname = nickname });
        }

        private void addOneJockey(EfContext context, string alias, string firstName, string middleName, string lastName, string dateTime)
        {
            context.Jockeys.Add(
                new Jockey
                {
                    Alias = alias,
                    FirstName = firstName,
                    LastName = lastName,
                    MiddleName = middleName,
                    DateBirth = DateTime.Parse(dateTime)
                });
        }
    }
}