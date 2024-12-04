using Logic.Interfaces;
using Logic.Interfaces.Table_Interfaces;
using Logic.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MitTecForlob.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InternshipGoalController : ControllerBase
    {
            private readonly IInternshipGoal _inter;
            private readonly IDataCollection _context;
            public InternshipGoalController(IDataCollection c)
            {
                _inter = c.InternshipGoal;
                _context = c;
            }
            #region GET Requests
            [HttpGet("{id}")]
            public async Task<ActionResult<InternshipGoal>> GetIntershipGoal(int id)
            {
                try
                {
                    var inter = await _inter.GetById(id);
                    if (inter == null)
                    {
                        return NotFound();
                    }
                    return inter;
                }
                catch (Exception ex)
                {

                    return BadRequest();
                }

            }
            [HttpGet("GetAllInternshipGoalsBy/{id}")]
            public async Task<ActionResult<List<InternshipGoal>>> GetAllCoursesById(int id)
            {
                try
                {
                    var inter = await _inter.GetAllInternshipGoalsToCourses(id);
                    if (inter == null)
                    {
                        return NotFound();
                    }
                    return inter;
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
            }
            #endregion
            #region POST Requests
            [HttpPost("CreateInternshipGoal")]
            public async Task<HttpStatusCode> CreateInternshipGoal(InternshipGoal inter)
            {
                try
                {
                    await _inter.Create(inter);
                }
                catch (Exception ex)
                {
                    return HttpStatusCode.BadRequest;
                }
                return HttpStatusCode.Created;
            }
            #endregion
            #region PUT Requests
            [HttpPut("UpdateInternshipGoal")]
            public async Task<HttpStatusCode> UpdateInternshipGoal(InternshipGoal inter)
            {
                try
                {
                    await _inter.Update(inter);
                }
                catch (Exception ex)
                {
                    return HttpStatusCode.BadRequest;
                }
                return HttpStatusCode.OK;
            }
            #endregion
            #region DELETE Requests
            [HttpDelete("DeleteInternshipGoal")]
            public async Task<HttpStatusCode> DeleteInternshipGoal(InternshipGoal inter)
            {
                try
                {
                    await _inter.Delete(inter);
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
