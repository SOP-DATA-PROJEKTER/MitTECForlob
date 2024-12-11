using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces.Table_Interfaces
{
    public interface IInternshipGoalCheck : IGeneric<InternshipGoalCheck>
    {
        public Task<InternshipGoalCheck> GetByCourseAndUser(int courseid,string useremail);
    }
}
