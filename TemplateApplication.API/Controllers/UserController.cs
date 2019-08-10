using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TemplateApplication.Data.Entities;
using TemplateApplication.Domain.Services.Interfaces;

namespace TemplateApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IBaseService<User> service;

        public UserController(IBaseService<User> service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("list")]
        public ActionResult List()
        {
            try
            {
                List<User> users = this.service.ListActives();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        [Route("find")]
        public ActionResult<string> Find(int id)
        {
            try
            {
                User user = this.service.FindById(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("add")]
        public ActionResult AddUser([FromBody] User newUser)
        {
            try
            {
                this.service.Add(newUser);
                return Ok("User added");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("addUsers")]
        public ActionResult AddUsers([FromBody] List<User> newUsers)
        {
            try
            {
                this.service.Add(newUsers);
                return Ok("Users added");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Route("update")]
        [HttpPost]
        public ActionResult UpdateUser([FromBody] User updatedUser)
        {
            try
            {
                this.service.Update(updatedUser);
                return Ok("User updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("updateUsers")]
        public ActionResult UpdateUsers([FromBody] List<User> updatedUsers)
        {
            try
            {
                this.service.Update(updatedUsers);
                return Ok("Users updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}