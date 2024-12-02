using Logic.Interfaces;
using Logic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models_Logic.Table_Repo
{
    public class SubjRepo : GenericRepo<Subj>, ISubj
    {
        DBcontext context;
        public SubjRepo(DBcontext c) : base(c)    
        {
            context = c;
        } // Dependency Injection - DI
        public async Task<List<Subj>> GetAllSubj()
        {
            try
            {
                return await context.Subj.ToListAsync();
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public async Task<Subj> GetById(int id)
        {
            return await context.Subj.FirstOrDefaultAsync(Subj => Subj.Id == id);
        }

        public async Task<Subj> GetBySubjName(string subjectname)
        {
            return await context.Subj.FirstOrDefaultAsync(Subj => Subj.SubjectName == subjectname);
        }
        public async Task<List<Subj>> GetAllSubjToCourses(int id)
        {
            return await context.Subj.Where(Subj => Subj.CourseId == id).ToListAsync();
        }
    }
}
