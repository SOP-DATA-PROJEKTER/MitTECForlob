using Logic.Interfaces.Table_Interfaces;
using Logic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models_Logic.Table_Repo
{
    public class InternshipGoalRepo : GenericRepo<InternshipGoal>, IInternshipGoal
    {
        DBcontext context;
        public InternshipGoalRepo(DBcontext c) : base(c)
        {
            context = c;
        } // Dependency Injection - DI
        public async Task<List<InternshipGoal>> GetAllInternship()
        {
            try
            {
                return await context.InternshipGoal.ToListAsync();
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public async Task<InternshipGoal> GetById(int id)
        {
            return await context.InternshipGoal.FirstOrDefaultAsync(InternshipGoal => InternshipGoal.Id == id);
        }

        public async Task<List<InternshipGoal>> GetAllInternshipGoalsToCourses(int id)
        {
            return await context.InternshipGoal.Where(InternshipGoal => InternshipGoal.CourseId == id).ToListAsync();
        }
    }
}
