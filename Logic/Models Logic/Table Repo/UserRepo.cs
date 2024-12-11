using Logic.Interfaces;
using Logic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models_Logic.Table_Repo
{
    public class UserRepo: GenericRepo<User>, IUser
    {
        DBcontext context;
        public UserRepo(DBcontext c) : base(c)
        {
            context = c;
        } // Dependency Injection - DI

        public async Task<User> GetByEmail(string email)
        {
            return await context.User
                .Include(ele => ele.Notes)
                .FirstOrDefaultAsync(Users => Users.Email == email);
        }
        public async Task<User> GetById(int id)
        {
            return await context.User
                .Include(ele => ele.Notes)
                .FirstOrDefaultAsync(Users => Users.Id == id);
        }
        public async Task<List<User>> GetListOfUsers()
        {
            try
            {
                return await context.User
                    .Include(ele => ele.Notes)
                    .ToListAsync();
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public async Task<bool> CheckLogin(LoginObject loginObject)
        {
            User UserFromDatabase = await GetByEmail(loginObject.Email);

            if (UserFromDatabase == null)
            {
                return false;
            }


            return false;

        }
    }
}
