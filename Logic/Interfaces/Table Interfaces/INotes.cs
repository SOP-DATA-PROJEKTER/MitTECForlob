using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces.Table_Interfaces
{
    public interface INotes
    {
        public Task<Notes> CreateNotes(Notes notes);
        public Task<Notes> GetById(int id);
        public Task<Notes> UpdateNotes(Notes notes);
        public Task<bool> DeleteNotes(int id);
    }
}
