using Logic.Interfaces;
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
    public class EducationRepo : GenericRepo<Education>,IEducation
    {
        DBcontext context;
        public EducationRepo(DBcontext c) : base(c)
        {
            context = c;
        } // Dependency Injection - DI

        public async Task<Education> GetByEduationName(string educationname)
        {
            return await context.Education.FirstOrDefaultAsync(Education => Education.EducationName == educationname);
        }
        public async Task<Education> GetById(int id)
        {
            return await context.Education.FirstOrDefaultAsync(Education => Education.Id == id);
        }
        public async Task<List<Education>> GetAllEducations()
        {
            try
            {
                return await context.Education.ToListAsync();
            }
            catch (Exception ex)
            {

            }
            return null;
        }
    }
}
