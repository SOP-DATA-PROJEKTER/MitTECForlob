using Logic.Interfaces.Table_Interfaces;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface ISubj : IGeneric<Subj>
    {
        public Task<Subj> GetBySubjName(string subjectname);
        public Task<Subj> GetById(int id);
        public Task<List<Subj>> GetAllSubj();
        public Task<List<Subj>> GetAllSubjToCourses(int id);
    }
}
