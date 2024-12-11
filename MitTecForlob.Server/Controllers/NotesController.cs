using Logic.Interfaces;
using Logic.Interfaces.Table_Interfaces;
using Logic.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MitTecForlob.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INotes _notes;
        private readonly IUser _user;
        private readonly ICourse _course;
        private readonly IDataCollection _context;
        public NotesController(IDataCollection c)
        {
            _notes = c.Notes;
            _user = c.User;
            _course = c.Course;
            _context = c;
        }
        #region GET Requests
        [HttpGet("{id}")]
        public async Task<ActionResult<Notes>> GetNotes(int id)
        {
            try
            {
                var notes = await _notes.GetById(id);
                if (notes == null)
                {
                    return NotFound();
                }
                return notes;
            }
            catch (Exception ex)
            {

                return BadRequest();
            }

        }
        #endregion
        #region POST Requests
        [HttpPost("CreateNotes")]
        public async Task<HttpStatusCode> CreateNotes(Notes notes)
        {
            try
            {
                await _notes.Create(notes);
            }
            catch (Exception ex)
            {
                return HttpStatusCode.BadRequest;
            }
            return HttpStatusCode.Created;
        }
        #endregion
        #region PUT Requests
        [HttpPut("UpdateNotes")]
        public async Task<HttpStatusCode> UpdateNotes(Notes notes)
        {
            try
            {
                await _notes.Update(notes);
            }
            catch (Exception ex)
            {
                return HttpStatusCode.BadRequest;
            }
            return HttpStatusCode.OK;
        }
        #endregion
        #region DELETE Requests
        [HttpDelete("DeleteNotes")]
        public async Task<HttpStatusCode> DeleteNotes(Notes notes)
        {
            try
            {
                await _notes.Delete(notes);
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
