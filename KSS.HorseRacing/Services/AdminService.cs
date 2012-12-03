namespace KSS.HorseRacing.Services
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Web.Mvc;

    using KSS.HorseRacing.Infrastucture.DataAccess;
    using KSS.HorseRacing.Infrastucture.DataModels;
    using KSS.HorseRacing.Infrastucture.Security;
    using KSS.HorseRacing.Models;

    public class AdminService
    {
        private readonly ICryptoProvider _cryptoProvider;

        public AdminService(ICryptoProvider cryptoProvider)
        {
            _cryptoProvider = cryptoProvider;
        }

        public List<UsersListModel> GetUsersListModel()
        {
            using (var unit = new UnitOfWork())
            {
                var users = unit.User.GetAll();
                var model = users.Select(user => new UsersListModel
                                                 {
                                                     UserId = user.Id,
                                                     Username = user.Username,
                                                     RoleName = user.Role != null ? user.Role.Name : string.Empty
                                                 }).ToList();
                return model;
            }
        }

        public UserEditViewModel GetUserEditModel(int id)
        {
            using (var unit = new UnitOfWork())
            {
                var user = unit.User.Get(id);
                var model = new UserEditViewModel { UserId = user.Id, Username = user.Username };
                var roles = unit.Role.GetAll();
                model.Roles = (from item in roles
                               select new SelectListItem
                                      {
                                          Text = item.Name,
                                          Value = item.Id.ToString(CultureInfo.InvariantCulture)
                                      }).ToList();
                model.SelectedRoleId = user.Role.Id;
                return model;
            }
        }

        public string EditUser(UserEditViewModel model)
        {
            using (var unit = new UnitOfWork())
            {
                var user = unit.User.Get(model.UserId);
                var newRole = unit.Role.Get(model.SelectedRoleId);

                var username = user.Username;

                user.Role = newRole;
                user.Username = model.Username;

                unit.User.SaveUser(user);
                return username;
            }
        }

        public bool CheckIfUserWithUsernameExist(string username)
        {
            using (var unit = new UnitOfWork())
            {
                var userByUsername = unit.User.GetUserByUsername(username);
                return userByUsername != null;
            }
        }

        public UserDetailsModel GetUserDetailsModel(int id)
        {
            using (var unit = new UnitOfWork())
            {
                var user = unit.User.Get(id);
                var model = new UserDetailsModel
                            {
                                UserId = user.Id,
                                UserRoleName = user.Role != null ? user.Role.Name : string.Empty,
                                Username = user.Username
                            };
                return model;
            }
        }

        public void DeleteUser(int id)
        {
            using (var unit = new UnitOfWork())
            {
                var user = unit.User.Get(id);
                unit.User.Delete(user);
            }
        }

        public void CreateUser(CreateUserViewModel model)
        {
            using (var unit = new UnitOfWork())
            {
                var role = unit.Role.Get(model.SelectedRole);
                var salt = _cryptoProvider.CreateSalt();
                var credentials = new Credentials
                                  {
                                      Salt = salt,
                                      PasswordHash = _cryptoProvider.CreateCryptoPassword(model.Username, salt)
                                  };
                var user = new User
                           {
                               Username = model.Username,
                               Password = credentials,
                               Role = role
                           };
                unit.User.SaveUser(user);
            }
        }

        public CreateUserViewModel GetCreateUserViewModel()
        {
            var model = new CreateUserViewModel();
            using (var unit = new UnitOfWork())
            {
                var roles = unit.Role.GetAll();
                model.RolesForDropdown = getRolesListForDropdown(roles);
            }
            return model;
        }

        private IEnumerable<SelectListItem> getRolesListForDropdown(IEnumerable<Role> roles)
        {
            roles = roles.OrderBy(x => x.Name);
            var listItems = roles.Select(role => new SelectListItem
                {
                    Text = role.Name,
                    Value = role.Id.ToString(CultureInfo.InvariantCulture)
                });
            return listItems;
        }
    }
}