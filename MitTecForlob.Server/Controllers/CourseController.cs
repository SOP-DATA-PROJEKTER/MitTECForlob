using Logic.Interfaces;
using Logic.Interfaces.Table_Interfaces;
using Logic.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MitTecForlob.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourse _course;
        private readonly ISubj _subject;
        private readonly IDataCollection _context;
        public CourseController(IDataCollection c)
        {
            _course = c.Course;
            _subject = c.Subj;
            _context = c;
        }
        #region GET Requests
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            try
            {
                var course = await _course.GetById(id);
                if (course == null)
                {
                    return NotFound();
                }
                return course;
            }catch (Exception ex) {

                return BadRequest();
            }

        }
        [HttpGet("GetAllCoursesBy/{id}")]
        public async Task<ActionResult<List<Course>>> GetAllCoursesById(int id)
        {
            try
            {
                var course = await _course.GetAllCoursesToSpecs(id);
                if (course == null)
                {
                    return NotFound();
                }
                return course;
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        #endregion
        #region POST Requests
        [HttpPost("CreateCourse")]
        public async Task<HttpStatusCode> CreateCourse(Course course)
        {
            try
            {
                await _course.Create(course);
            }
            catch (Exception ex)
            {
                return HttpStatusCode.BadRequest;
            }
            return HttpStatusCode.Created;
        }
        #endregion
        #region PUT Requests
        [HttpPut("UpdateCourse")]
        public async Task<HttpStatusCode> UpdateCourse(Course course)
        {
            try
            {
                await _course.Update(course);
            }
            catch (Exception ex)
            {
                return HttpStatusCode.BadRequest;
            }
            return HttpStatusCode.OK;
        }
        #endregion
        #region DELETE Requests
        [HttpDelete("DeleteCourse")]
        public async Task<HttpStatusCode> DeleteCourse(Course course)
        {
            try
            {
                await _course.Delete(course);
            }
            catch (Exception ex)
            {
                return HttpStatusCode.BadRequest;
            }
            return HttpStatusCode.OK;
        }
        #endregion
    }
}
