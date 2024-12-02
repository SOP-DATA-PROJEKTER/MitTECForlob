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
    public class CourseRepo : GenericRepo<Course>,ICourse
    {
        DBcontext context;
        public CourseRepo(DBcontext c) : base(c)
        {
            context = c;
        } // Dependency Injection - DI
        public async Task<Course> GetById(int id)
        {
            return await context.Course.FirstOrDefaultAsync(Progress => Progress.Id == id);
        }
        public async Task<List<Course>> GetAllCourses()
        {
            try
            {
                return await context.Course.ToListAsync();
            }
            catch (Exception ex)
            {

            }
            return null;
        }
        public async Task<List<Course>> GetAllCoursesToSpecs(int specsId)
        {
            try
            {
                return await context.Course.Where(Course => Course.SpecsId == specsId).ToListAsync();
            }
            catch (Exception ex)
            {
            }
            return null;
        }
    }
}
