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
        public Task<Education> CreateEducation(Education education);
        public Task<Education> GetByEduationName(string educationname);
        public Task<Education> GetById(int id);
        public Task<List<Education>> GetAllEducations();
        public Task<Education> UpdateEducation(Education education);
        public Task<Education> DeleteEducation(int id);
    }
}
