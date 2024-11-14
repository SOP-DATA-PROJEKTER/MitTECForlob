using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IUser
    {
        public Task<User> CreateUser(User user);
        public Task<User> GetByEmail(string email);
        public Task<User> GetById(int id);
        public Task<List<User>> GetListOfUsers();
        public Task<bool> CheckLogin(LoginObject loginObject);
        public Task<User> UpdateUser(User user);
        public Task<bool> DeleteUser(int id);
    }
}
