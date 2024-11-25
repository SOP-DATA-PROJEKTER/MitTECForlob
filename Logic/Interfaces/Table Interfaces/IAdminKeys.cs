using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces.Table_Interfaces
{
    public interface IAdminKeys: IGeneric<AdminKeys>
    {
        public Task<AdminKeys> GetByKey(string adminkey);
        public Task<AdminKeys> GetById(int id);
        public Task<List<AdminKeys>> GetAllAdminKeys();
    }
}
