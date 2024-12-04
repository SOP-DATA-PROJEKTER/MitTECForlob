using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces.Table_Interfaces
{
    public interface IInternshipGoal : IGeneric<InternshipGoal>
    {
        public Task<InternshipGoal> GetById(int id);
        public Task<List<InternshipGoal>> GetAllInternship();
        public Task<List<InternshipGoal>> GetAllInternshipGoalsToCourses(int id);
    }
}
