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
            const string PASSWORD = "password";
            var admin = new User
            {
                Username = "admin",
                Password = new Credentials
                                {
                                    Salt = salt,
                                    PasswordHash = cryptoProvider.CreateCryptoPassword(PASSWORD, salt)
                                },
                Role = context.Roles.FirstOrDefault(x => x.Name == Role.ADMIN)
            };
            context.Users.Add(admin);

            salt = cryptoProvider.CreateSalt();
            var judge = new User
                        {
                            Username = "judge",
                            Password = new Credentials
                                       {
                                           Salt = salt,
                                           PasswordHash = cryptoProvider.CreateCryptoPassword(PASSWORD, salt)
                                       },
                            Role = context.Roles.FirstOrDefault(x => x.Name == Role.JUDGE)
                        };
            context.Users.Add(judge);

            salt = cryptoProvider.CreateSalt();
            var jokey = new User
            {
                Username = "joсkey",
                Password = new Credentials
                {
                    Salt = salt,
                    PasswordHash = cryptoProvider.CreateCryptoPassword(PASSWORD, salt)
                },
                Role = context.Roles.FirstOrDefault(x => x.Name == Role.USER)
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
            addOneJockey(context, "Лазер", "Александр", "Сергеевич", "Твидов", DateTime.Now.AddYears(-5));
            addOneJockey(context, "Лунный свет", "Мария", "Александровна", "Ежелева", DateTime.Now.AddYears(-5));
            addOneJockey(context, "Воин", "Николай", "Михайлович", "Иванов", DateTime.Now.AddYears(-5));
            addOneJockey(context, "Камень", "Евгений", "Николаевич", "Селезнев", DateTime.Now.AddYears(-5));
            context.SaveChanges();
        }

        private void addHorses(EfContext context)
        {
            addOneHorse(context, "Счастливица");
            addOneHorse(context, "Звёздочка");
            addOneHorse(context, "Милорд");
            addOneHorse(context, "Буря");
            context.SaveChanges();
        }

        private void addOneHorse(EfContext context, string nickname)
        {
            var years = new Random().Next(1, 7);
            context.Horses.Add(
                new Horse
                {
                    Nickname = nickname,
                    DateBirth = DateTime.Now.AddYears(-years)
                    
                });
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