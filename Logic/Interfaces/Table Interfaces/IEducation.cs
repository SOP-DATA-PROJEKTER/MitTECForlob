using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IEducation
    {
        public Task<Education> GetByEduationName(string educationname);
        public Task<Education> GetById(int id);
        public Task<List<Education>> GetAllEducations();
    }
}
