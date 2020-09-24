using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroService.Models;

namespace UserMicroService.Services
{
   public interface IUserService
    {
        IEnumerable<User> GetUsers();
        bool UserExists(int Id);
        bool UserNameExists(string UserName);
        User GetUserById(int Id);
        User GetUser(string UserNaem);
        void Create(User User);
        void Update(User User);
        void Delete(User User);


    }
}
