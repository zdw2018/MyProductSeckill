using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroService.Models;
using UserMicroService.Repositories;

namespace UserMicroService.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRespository _userRespository;
        public UserService(IUserRespository userRespository)
        {
            this._userRespository = userRespository;
        }
        public void Create(User User)
        {
            _userRespository.Create(User);
        }

        public void Delete(User User)
        {
            _userRespository.Delete(User);
        }

        public User GetUser(string UserNaem)
        {
          return  _userRespository.GetUser(UserNaem);
        }

        public User GetUserById(int Id)
        {
            return _userRespository.GetUserById(Id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _userRespository.GetUsers();
        }

        public void Update(User User)
        {
            _userRespository.Update(User);
        }

        public bool UserExists(int Id)
        {
            return _userRespository.UserExists(Id);
        }

        public bool UserNameExists(string UserName)
        {
            return _userRespository.UserNameExists(UserName);
        }
    }
}
