using Logic.Interfaces;
using Logic.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MitTecForlob.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecsController : ControllerBase
    {
        private readonly ISpecs _specs;
        private readonly ICourse _course;
        private readonly IDataCollection _context;
        public SpecsController(IDataCollection c)
        {
            _course = c.Course;
            _specs = c.Specs;
            _context = c;
        }
        #region GET Requests
        [HttpGet("{id}")]
        public async Task<ActionResult<Specs>> GetSpecs(int id)
        {
            try
            {
                var specs = await _specs.GetById(id);
                if (specs == null)
                {
                    return NotFound();
                }
                return specs;
            }
            catch (Exception ex)
            {

                return BadRequest();
            }

        }
        [HttpGet("{name}")]
        public async Task<ActionResult<Specs>> GetBySpecsName(string specsname)
        {
            try
            {
                var specs = await _specs.GetBySpecsName(specsname);
                if (specs == null)
                {
                    return NotFound();
                }
                return specs;
            }
            catch (Exception ex)
            {

                return BadRequest();
            }

        }
        [HttpGet("{name}")]
        public async Task<ActionResult<Specs>> GetBySpecsName(string specsname)
        {
            try
            {
                var specs = await _specs.GetBySpecsName(specsname);
                if (specs == null)
                {
                    return NotFound();
                }
                return specs;
            }
            catch (Exception ex)
            {

                return BadRequest();
            }

        }
        #endregion
        #region POST Requests
        [HttpPost("CreateSpecs")]
        public async Task<HttpStatusCode> CreateSpecs(Specs specs)
        {
            try
            {
                await _specs.Create(specs);
            }
            catch (Exception ex)
            {
                return HttpStatusCode.BadRequest;
            }
            return HttpStatusCode.Created;
        }
        #endregion
        #region PUT Requests
        [HttpPut("UpdateSpecs")]
        public async Task<HttpStatusCode> UpdateSpecs(Specs specs)
        {
            try
            {
                await _specs.Update(specs);
            }
            catch (Exception ex)
            {
                return HttpStatusCode.BadRequest;
            }
            return HttpStatusCode.OK;
        }
        #endregion
        #region DELETE Requests
        [HttpDelete("DeleteSpecs")]
        public async Task<HttpStatusCode> DeleteSpecs(Specs specs)
        {
            try
            {
                await _specs.Delete(specs);
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
