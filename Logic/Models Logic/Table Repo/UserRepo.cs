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
            return await context.User.FirstOrDefaultAsync(Users => Users.Email == email);
        }
        public async Task<User> GetById(int id)
        {
            return await context.User.FirstOrDefaultAsync(Users => Users.Id == id);
        }
        public async Task<List<User>> GetListOfUsers()
        {
            try
            {
                return await context.User.ToListAsync();
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

            if (ValidatePassword(loginObject.Password, UserFromDatabase.Password))
            {
                return true;
            }

            return false;

        }
        public bool ValidatePassword(string HashedPasswordAttempt, string PasswordHashFromDatabase)
        {
            try
            {
                byte[] HashedPasswordAttemptBase64Decoded = Convert.FromBase64String(HashedPasswordAttempt);
                byte[] PasswordHashFromDatabaseBase64Decoded = Convert.FromBase64String(PasswordHashFromDatabase);

                if (CompareByteArrays(HashedPasswordAttemptBase64Decoded, PasswordHashFromDatabaseBase64Decoded))
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private bool CompareByteArrays(byte[] A, byte[] B)
        {
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] != B[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
