using Logic.Interfaces.Table_Interfaces;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IUser : IGeneric<User>
    {
        public Task<User> GetByEmail(string email);
        public Task<User> GetById(int id);
        public Task<List<User>> GetListOfUsers();
        public Task<bool> CheckLogin(LoginObject loginObject);
    }
}
