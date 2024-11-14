using Logic.Interfaces.Table_Interfaces;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IProgress : IGeneric<Progress>
    {
        public Task<Progress> GetByProgressName(string progressname);
        public Task<Progress> GetById(int id);
        public Task<List<Progress>> GetAllProgress();
    }
}
