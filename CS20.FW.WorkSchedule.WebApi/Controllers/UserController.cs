using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS20.FW.WorkSchedule.Core.IService;
using CS20.FW.WorkSchedule.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CS20.FW.WorkSchedule.WebApi.Controllers
{
    [Route("api/[controller]")]
    // [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<UserDto[]> GetAllUsers()
        {
            try
            {
                var users = _userService.GetUsers();
                var userDtos = new List<UserDto>();
                foreach (var user in users)
                {
                    userDtos.Add(new UserDto()
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Role = user.Role
                    });
                }

                return Ok(userDtos.ToArray());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        } 
    }
}