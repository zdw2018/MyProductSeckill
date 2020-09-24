using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroService.Context;
using UserMicroService.Models;

namespace UserMicroService.Repositories
{
    public class UserRespository : IUserRespository
    {
        private readonly UserContext _userContext;
        public UserRespository(UserContext userContext)
        {
            this._userContext = userContext;
        }
        public void Create(User User)
        {            
            this._userContext.Set<User>().Add(User);
            this._userContext.SaveChanges();
        }

        public void Delete(User User)
        {
            this._userContext.Set<User>().Remove(User);
            this._userContext.SaveChanges();
        }

        public User GetUser(string UserName)
        {
           User user= this._userContext.Set<User>().First(u=>u.UserName==UserName);
            return user;
        }

        public User GetUserById(int Id)
        {
            User user = this._userContext.Set<User>().Find(Id);
            return user;
        }

        public IEnumerable<User> GetUsers()
        {
            return _userContext.Set<User>().ToList();
        }

        public void Update(User User)
        {
            this._userContext.Set<User>().Update(User);
            this._userContext.SaveChanges();
        }

        public bool UserExists(int Id)
        {
            return this._userContext.Set<User>().Any(e => e.Id == Id);
        }

        public bool UserNameExists(string UserName)
        {
            return this._userContext.Set<User>().Any(e => e.UserName == UserName);
        }
    }
}
