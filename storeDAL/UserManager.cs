using Azure.Core;
using storeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using BCrypt.Net;

namespace storeDAL
{
    public interface IUserManager 
    {
        public void AddUser(string username, string password);
        public void RemoveUser(string username);
        public bool UpdateUser();
        public List<User> GetAllUsers();
        public User? GetUser(string username);

        }
    public class UserManager:  IUserManager
    {

        private readonly DBContext _entityContext;
        public UserManager(DBContext entityContext) { _entityContext = entityContext; }

        public void AddUser(string username, string password)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            User user = new User();
            user.Id = Guid.NewGuid();
            user.Username = username;
            user.Passwordhash = passwordHash;

            _entityContext.Users.Add(user);
            _entityContext.SaveChanges();
            }
        
        public void RemoveUser(string username) {
           
                User? user = new User() { };
                user= _entityContext.Users.Where(a=>a.Username== username).FirstOrDefault();
                if (user != null)
                {
            _entityContext.Users.Remove(user);
            _entityContext.SaveChanges();
                }
                else
                { //write to log
                  }
                
            
        }
        public bool UpdateUser() { return false; }
        public List<User> GetAllUsers() {
            List<User> users=   new List<User>();
           

                users = _entityContext.Users.ToList();
             

            
            return users;
        }
        public User? GetUser(string username)
        {
            return _entityContext.Users.Where(a => a.Username == username).FirstOrDefault();
            }
    }
}
