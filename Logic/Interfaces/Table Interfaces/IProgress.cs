using Logic.Interfaces.Table_Interfaces;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IProgress : IGeneric<Course>
    {
        public Task<Course> GetByProgressName(string progressname);
        public Task<Course> GetById(int id);
        public Task<List<Course>> GetAllProgress();
    }
}
