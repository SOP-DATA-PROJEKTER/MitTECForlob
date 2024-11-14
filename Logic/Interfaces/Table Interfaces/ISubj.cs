using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface ISubj
    {
        public Task<Subj> CreateSubj(Subj subj);
        public Task<Subj> GetBySubjName(string subjectname);
        public Task<Subj> GetById(int id);
        public Task<List<Subj>> GetAllSubj();
        public Task<Subj> UpdateSubj(Subj subj);
        public Task<bool> DeleteSubj(int id);

    }
}
