using System.Linq;
using System.Collections.Generic;
using sofTech.Models;
using Entity;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace sofTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController:ControllerBase
    {
        private readonly UserService userService;

        public UserController(){
            userService = new UserService();

        }

        [HttpGet]
        public IEnumerable<UserViewModel> Get(){
            var users = userService.FindUsers().Objects.Select(u => new UserViewModel((User)u));
            return users;
        }

        [HttpGet("{id}")]
        public ActionResult<UserViewModel> GetByID(string id){
            var user = (User)userService.FindUserByID(id).Object;
            if(user==null){
                return NotFound();
            }

            return new UserViewModel(user);

        }

        public User MapUser(UserInputModel userInputModel){
            User user = new User();
            user.IDUser_ = userInputModel.IDUser;
            user.Name_ = userInputModel.Name;
            user.Password_ = userInputModel.Password;
            user.State_ = userInputModel.State;

            return user;
        }

        [HttpPost]
        public ActionResult<User> Post(UserInputModel userInputModel){
            var user = MapUser(userInputModel);
            var Response = userService.SaveUser(user);
            if(Response.Error){
                return BadRequest(Response.Message);
            }
            return Ok((User)Response.Object);
        }

        [HttpDelete("{id}")]
        public ActionResult<string> Delete(string id){

            User user = (User) userService.FindUserByID(id).Object;
            user.State_ = "Inactivo";
            return Ok(userService.UpdateUser(user).Message);

        }

        [HttpPut]
        public ActionResult<User> UpdateUser(UserInputModel userInputModel){
            var user = MapUser(userInputModel);
            var Response = userService.UpdateUser(user);
            if(Response.Error){
                return BadRequest(Response.Message);
            }
            return Ok(user);
        }

    }
}