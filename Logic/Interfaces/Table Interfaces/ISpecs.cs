using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Models;

namespace Logic.Interfaces
{
    public interface ISpecs
    {
        public Task<Specs> GetBySpecializationName (string progressname);
        public Task<Specs> GetById(int id);
        public Task<List<Specs>> GetAllSpecs();
    }
}
