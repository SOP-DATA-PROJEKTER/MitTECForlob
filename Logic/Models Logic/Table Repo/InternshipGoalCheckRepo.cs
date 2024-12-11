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
    public class InternshipGoalCheckRepo : GenericRepo<InternshipGoalCheck>, IInternshipGoalCheck
    {
        DBcontext context;
        public InternshipGoalCheckRepo(DBcontext c) : base(c)
        {
            context = c;
        } // Dependency Injection - DI
        public async Task<InternshipGoalCheck> GetByCourseAndUser(int courseid, string email)
        {
            try
            {
                var user = await context.User.FirstOrDefaultAsync(u => u.Email == email);
                if (user == null)
                    return null;

                var internshipGoalCheck = await context.InternshipGoalCheck
                    .FirstOrDefaultAsync(igc => igc.CourseId == courseid && igc.UserId == user.Id);

                return internshipGoalCheck;
            }
            catch (Exception ex)
            {
                // Log the exception
                return null;
            }
        }

    }
}
