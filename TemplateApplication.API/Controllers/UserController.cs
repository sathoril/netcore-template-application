using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TemplateApplication.Domain.Entities;
using TemplateApplication.Domain.Entities.Logs;
using TemplateApplication.Domain.Services.Interfaces;

namespace TemplateApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IBaseService<User> service;
        private readonly ILogService<ApplicationLog> applicationLog;

        public UserController(IBaseService<User> service, ILogService<ApplicationLog> applicationLog)
        {
            this.service = service;
            this.applicationLog = applicationLog;
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
            catch(Exception ex)
            {
                this.applicationLog.LogApplicationInfo("Teste");
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("find")]
        public ActionResult<string> Find(int id)
        {
            User user = this.service.FindById(id);
            return Ok(user);
        }

        [HttpPost]
        [Route("add")]
        public ActionResult AddUser([FromBody] User newUser)
        {
            this.service.Add(newUser);
            return Ok("User added");
        }

        [HttpPost]
        [Route("addUsers")]
        public ActionResult AddUsers([FromBody] List<User> newUsers)
        {
            this.service.Add(newUsers);
            return Ok("Users added");
        }

        [Route("update")]
        [HttpPost]
        public ActionResult UpdateUser([FromBody] User updatedUser)
        {
            this.service.Update(updatedUser);
            return Ok("User updated");
        }

        [HttpPost]
        [Route("updateUsers")]
        public ActionResult UpdateUsers([FromBody] List<User> updatedUsers)
        {
            this.service.Update(updatedUsers);
            return Ok("Users updated");
        }
    }
}