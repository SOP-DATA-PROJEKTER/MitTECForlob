using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces.Table_Interfaces
{
    public interface INotes : IGeneric<Notes>
    {
        public Task<Notes> GetById(int id);
    }
}
