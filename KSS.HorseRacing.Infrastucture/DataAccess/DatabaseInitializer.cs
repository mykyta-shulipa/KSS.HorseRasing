namespace KSS.HorseRacing.Infrastucture.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using KSS.HorseRacing.Infrastucture.DataModels;
    using KSS.HorseRacing.Infrastucture.Security;

    public class DatabaseInitializer : DropCreateDatabaseAlways<EfContext>
    {
        protected override void Seed(EfContext context)
        {
            addJockeys(context);

            addHorses(context);

            addRoles(context);

            addUsers(context);

            context.SaveChanges();
        }

        private void addUsers(EfContext context)
        {
            var cryptoProvider = new CryptoProviderMd5();
            var salt = cryptoProvider.CreateSalt();
            var admin = new User
            {
                Username = "admin",
                Password = new SecureCredentials
                                {
                                    Salt = salt,
                                    PasswordHash = cryptoProvider.CreateCryptoPassword("password", salt)
                                },
                UserRole = context.Roles.FirstOrDefault(x => x.Name == Role.ADMIN)
            };
            context.Users.Add(admin);

            salt = cryptoProvider.CreateSalt();
            var judge = new User
                        {
                            Username = "judge",
                            Password = new SecureCredentials
                                       {
                                           Salt = salt,
                                           PasswordHash = cryptoProvider.CreateCryptoPassword("password", salt)
                                       }
                        };
            context.Users.Add(judge);

            salt = cryptoProvider.CreateSalt();
            var jokey = new User
            {
                Username = "jokey",
                Password = new SecureCredentials
                {
                    Salt = salt,
                    PasswordHash = cryptoProvider.CreateCryptoPassword("password", salt)
                }
            };
            context.Users.Add(jokey);
            context.SaveChanges();
        }

        private void addRoles(EfContext context)
        {
            context.Roles.Add(new Role { Name = Role.ADMIN });
            context.Roles.Add(new Role { Name = Role.USER });
            context.Roles.Add(new Role { Name = Role.JUDGE });
            context.SaveChanges();
        }

        private void addJockeys(EfContext context)
        {
            addOneJockey(context, "Hero", "Alexandr", "Sergeevich", "Tvidov", DateTime.Now.AddYears(-5));
            addOneJockey(context, "Moonlight", "Maria", "Olegovna", "Kurilo", DateTime.Now.AddYears(-5));
            addOneJockey(context, "Warrior", "Nikolay", "Mikhailovitch", "Ivanov", DateTime.Now.AddYears(-5));
            addOneJockey(context, "Stone", "Eugeniy", "Alexandrovich", "Seleznev", DateTime.Now.AddYears(-5));
            context.SaveChanges();
        }

        private void addHorses(EfContext context)
        {
            addOneHorse(context, "Lucky");
            addOneHorse(context, "Star");
            addOneHorse(context, "Milord");
            addOneHorse(context, "Storm");
            context.SaveChanges();
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

        private void addOneJockey(EfContext context, string alias, string firstName, string middleName, string lastName, DateTime dateTime)
        {
            context.Jockeys.Add(
                new Jockey
                {
                    Alias = alias,
                    FirstName = firstName,
                    LastName = lastName,
                    MiddleName = middleName,
                    DateBirth = dateTime
                });
        }
    }
}