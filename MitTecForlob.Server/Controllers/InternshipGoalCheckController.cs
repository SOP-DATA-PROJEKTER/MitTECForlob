using Logic.Interfaces.Table_Interfaces;
using Logic.Interfaces;
using Logic.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MitTecForlob.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InternshipGoalCheckController : ControllerBase
    {
        private readonly IInternshipGoalCheck _internshipGoalCheck;
        private readonly IUser _user;
        private readonly ICourse _course;
        private readonly IDataCollection _context;
        public InternshipGoalCheckController(IDataCollection c)
        {
            _internshipGoalCheck = c.InternshipGoalCheck;
            _user = c.User;
            _course = c.Course;
            _context = c;
        }
        #region GET Requests
        [HttpGet("{courseid}/{email}")]
        public async Task<ActionResult<InternshipGoalCheck>> GetByEmailAndCourseId(int courseid, string email)
        {
            try
            {
                InternshipGoalCheck tmp = await _internshipGoalCheck.GetByCourseAndUser(courseid, email);
                if (tmp == null)
                {
                    return NotFound();
                }
                return Ok(tmp);
            }
            catch (Exception ex)
            {
                // Optionally log the exception
                return BadRequest();
            }
        }

        #endregion
        #region POST Requests
        [HttpPost("CreateInternshipGoalCheck")]
        public async Task<HttpStatusCode> CreateInternshipGoalCheck(InternshipGoalCheck tmp)
        {
            try
            {
                await _internshipGoalCheck.Create(tmp);
            }
            catch (Exception ex)
            {
                return HttpStatusCode.BadRequest;
            }
            return HttpStatusCode.Created;
        }
        #endregion
        #region PUT Requests
        [HttpPut("UpdateInternshipGoalCheck")]
        public async Task<HttpStatusCode> UpdateInternshipGoalCheck(InternshipGoalCheck tmp)
        {
            try
            {
                await _internshipGoalCheck.Update(tmp);
            }
            catch (Exception ex)
            {
                return HttpStatusCode.BadRequest;
            }
            return HttpStatusCode.OK;
        }
        #endregion
        #region DELETE Requests
        [HttpDelete("DeleteInternshipGoalCheck")]
        public async Task<HttpStatusCode> DeleteInternshipGoalCheck(InternshipGoalCheck tmp)
        {
            try
            {
                await _internshipGoalCheck.Delete(tmp);
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
