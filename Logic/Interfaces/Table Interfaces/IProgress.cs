using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IProgress
    {
        public Task<Progress> CreateNotes(Notes notes);
        public Task<Progress> GetByProgressName(string progressname);
        public Task<Progress> GetById(int id);
        public Task<List<Progress>> GetAllProgress();
        public Task<Progress> UpdateNotes(Notes notes);
        public Task<bool> DeleteNotes(int id);
    }
}
