using Logic.Interfaces.Table_Interfaces;
using Logic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models_Logic.Table_Repo
{
    public class AdminKeysRepo : GenericRepo<AdminKeys>, IAdminKeys
    {
        DBcontext context;
        public AdminKeysRepo(DBcontext c) : base(c)
        {
            context = c;
        } // Dependency Injection - DI

        public async Task<AdminKeys> GetByKey(string adminkey)
        {
            return await context.AdminKeys.FirstOrDefaultAsync(AdminKeys => AdminKeys.Key == adminkey);
        }
        public async Task<AdminKeys> GetById(int id)
        {
            return await context.AdminKeys.FirstOrDefaultAsync(AdminKeys => AdminKeys.Id == id);
        }
        public async Task<List<AdminKeys>> GetAllAdminKeys()
        {
            try
            {
                return await context.AdminKeys.ToListAsync();
            }
            catch (Exception ex)
            {

            }
            return null;
        }
    }
}
