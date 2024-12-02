using Logic.Interfaces;
using Logic.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MitTecForlob.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjController : ControllerBase
    {
        private readonly ISubj _subj;
        private readonly IDataCollection _context;
        public SubjController(IDataCollection c)
        {
            _subj = c.Subj;
            _context = c;
        }
        #region GET Requests
        [HttpGet("{id}")]
        public async Task<ActionResult<Subj>> GetSubj(int id)
        {
            try
            {
                var subj = await _subj.GetById(id);
                if (subj == null)
                {
                    return NotFound();
                }
                return subj;
            }
            catch (Exception ex)
            {

                return BadRequest();
            }

        }
        [HttpGet("GetAllSubjBy/{id}")]
        public async Task<ActionResult<List<Subj>>> GetAllCoursesById(int id)
        {
            try
            {
                var subj = await _subj.GetAllSubjToCourses(id);
                if (subj == null)
                {
                    return NotFound();
                }
                return subj;
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        #endregion
        #region POST Requests
        [HttpPost("CreateSubj")]
        public async Task<HttpStatusCode> CreateSubj(Subj subj)
        {
            try
            {
                await _subj.Create(subj);
            }
            catch (Exception ex)
            {
                return HttpStatusCode.BadRequest;
            }
            return HttpStatusCode.Created;
        }
        #endregion
        #region PUT Requests
        [HttpPut("UpdateSubj")]
        public async Task<HttpStatusCode> UpdateSpecs(Subj subj)
        {
            try
            {
                await _subj.Update(subj);
            }
            catch (Exception ex)
            {
                return HttpStatusCode.BadRequest;
            }
            return HttpStatusCode.OK;
        }
        #endregion
        #region DELETE Requests
        [HttpDelete("DeleteSubj")]
        public async Task<HttpStatusCode> DeleteSpecs(Subj subj)
        {
            try
            {
                await _subj.Delete(subj);
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
