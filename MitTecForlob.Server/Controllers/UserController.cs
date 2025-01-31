﻿using Logic.Interfaces.Table_Interfaces;
using Logic.Interfaces;
using Logic.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MitTecForlob.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly INotes _notes;
        private readonly IInternshipGoalCheck _internshipGoalCheck;
        private readonly IUser _user;
        private readonly IDataCollection _context;
        public UserController(IDataCollection c)
        {
            _notes = c.Notes;
            _user = c.User;
            _internshipGoalCheck = c.InternshipGoalCheck;
            _context = c;
        }
        #region GET Requests
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            try
            {
                var user = await _user.GetById(id);
                if (user == null)
                {
                    return NotFound();
                }
                return user;
            }
            catch (Exception ex)
            {

                return BadRequest();
            }

        }
        [HttpGet("Getby{email}")]
        public async Task<ActionResult<User>> GetUserByEmail(string email)
        {
            try
            {
                var user = await _user.GetByEmail(email);
                if (user == null)
                {
                    return NotFound();
                }
                return user;
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        #endregion
        #region POST Requests
        [HttpPost("CreateUser")]
        public async Task<HttpStatusCode> CreateUser(User user)
        {
            try
            {
                await _user.Create(user);
            }
            catch (Exception ex)
            {
                return HttpStatusCode.BadRequest;
            }
            return HttpStatusCode.Created;
        }
        #endregion
        #region PUT Requests
        [HttpPut("UpdateUser")]
        public async Task<HttpStatusCode> UpdateUser(User user)
        {
            try
            {
                await _user.Update(user);
            }
            catch (Exception ex)
            {
                return HttpStatusCode.BadRequest;
            }
            return HttpStatusCode.OK;
        }
        #endregion
        #region DELETE Requests
        [HttpDelete("DeleteUser")]
        public async Task<HttpStatusCode> DeleteUser(User user)
        {
            try
            {
                await _user.Delete(user);
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
