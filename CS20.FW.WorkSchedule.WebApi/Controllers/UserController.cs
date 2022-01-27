using System;
using System.Collections.Generic;
using CS20.FW.WorkSchedule.Core.IService;
using CS20.FW.WorkSchedule.WebApi.Model;
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
                    userDtos.Add(new UserDtoConvert().ConverterUserDto(user));
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