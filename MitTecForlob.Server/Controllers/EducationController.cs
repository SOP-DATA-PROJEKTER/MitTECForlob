using Logic.Interfaces;
using Logic.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MitTecForlob.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : Controller
    {
        private readonly IEducation _education;
        private readonly ISpecs _specs;
        private readonly IDataCollection _context;
          public EducationController(IDataCollection c)
            {
                _education = c.Education;
                _specs = c.Specs;
                _context = c;
            }
            #region GET Requests
            [HttpGet("{id}")]
            public async Task<ActionResult<Education>> GetById(int id)
            {
            try
            {
                var education = await _education.GetById(id);
                if (education == null)
                {
                    return NotFound();
                }
                return education;
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
            return null;
            }
        [HttpGet("GetAllEducations")]
        public async Task<ActionResult<List<Education>>> GetAllEducations()
        {
            try
            {
                var education = await _education.GetAllEducations();
                if (education == null)
                {
                    return NotFound(); ;
                }
                return education;
            }
            catch (Exception ex)
            {

                return BadRequest();
            }

        }
        [HttpGet("{name}")]
            public async Task<ActionResult<Education>> GetByEduationName(string educationname)
            {
                try
                {
                    var education = await _education.GetByEduationName(educationname);
                    if (education == null)
                    {
                        return NotFound();
                    }
                    return education;
                }
                catch (Exception ex)
                {

                    return BadRequest();
                }

            }
        #endregion
            #region POST Requests
        [HttpPost("CreateEducation")]
            public async Task<HttpStatusCode> CreateEducation(Education education)
            {
                try
                {
                    await _education.Create(education);
                }
                catch (Exception ex)
                {
                    return HttpStatusCode.BadRequest;
                }
                return HttpStatusCode.Created;
            }
            #endregion
            #region PUT Requests
            [HttpPut("UpdateEducation")]
            public async Task<HttpStatusCode> UpdateEducation(Education education)
            {
                try
                {
                    await _education.Update(education);
                }
                catch (Exception ex)
                {
                    return HttpStatusCode.BadRequest;
                }
                return HttpStatusCode.OK;
            }
            #endregion
            #region DELETE Requests
            [HttpDelete("DeleteEducation")]
            public async Task<HttpStatusCode> DeleteEducation(Education education)
            {
                try
                {
                    await _education.Delete(education);
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
