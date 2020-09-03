using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using LearnToLearn.DataAccess;
using LearnToLearn.Models;
using LearnToLearn.Repositories;
using AutoMapper;
using LearnToLearn.BindingModels;
using LearnToLearn.Services;
using System.Web.Http.ModelBinding;
using System.Security.Claims;
using System.Linq;

namespace LearnToLearn.Controllers
{
    public class UsersController : ApiController
    {
        private BaseRepository<Users> _repository;
        private UserService _service;
        private ModelStateDictionary _modelState;

        public UsersController()
        {
            this._repository = new BaseRepository<Users>();
            this._modelState = new ModelStateDictionary();
            this._service = new UserService(_modelState, _repository);
        }

        [HttpGet]
        [Route("api/users/authenticate")]
        [Authorize]
        public IHttpActionResult GetForAuthenticate()
        {
            ClaimsIdentity claimsIdentity = User.Identity as ClaimsIdentity;
            var claims = claimsIdentity.Claims.Select(x => new { type = x.Type, value = x.Value });

            return Ok(claims);

        }

        [HttpGet]
        [Route("api/users/authorize")]
        [Authorize(Roles = "admin")]
        public IHttpActionResult GetForAdmin()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims
                        .Where(c => c.Type == ClaimTypes.Role)
                        .Select(c => c.Value);
            return Ok("Hello " + identity.Name + " Role " + string.Join(",", roles.ToList()));
        }

        [Route("api/users")]
        [ResponseType(typeof(Users))]
        public IHttpActionResult GetUsers()
        {
            var users = _service.ListUsers();
            var bindingModel = Mapper.Map<List<UsersBindingModels>>(users);

            return Ok(bindingModel);

        }

        [Route("api/users/{id}")]
        [ResponseType(typeof(Users))]
        public IHttpActionResult GetUser(int id)
        {
            var user = _service.GetUser(id);
            var bindingModel = Mapper.Map<UsersBindingModels>(user);

            if (bindingModel == null)
            {
                return NotFound();
            }
            return Ok(bindingModel);
        }

        [Route("api/users")]
        public IHttpActionResult Post([FromBody] UsersBindingModels userBindingModel)
        {
            Users user = new Users();
            var newUser = Mapper.Map(userBindingModel, user);

            _service.CreateUser(newUser);
            _service.SaveChanges();
            return Ok();
        }

        [Route("api/users/{id}")]
        public IHttpActionResult Put([FromBody] UsersBindingModels userBindingModel)
        {
            Users user = new Users();
            var id = user.Id;
            user = _service.GetUser(id);
            var newUser = Mapper.Map(userBindingModel, user);

            _service.EditUser(newUser);
            _service.SaveChanges();
            return Ok();
        }

        [Route("api/users/{id}")]
        public IHttpActionResult DeleteUser(UsersBindingModels usersBindingModel, int? id)
        {
            var user = _service.GetUser(id.Value);

            var bindingModel = Mapper.Map<UsersBindingModels>(user);

            if (id == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _service.DeleteUser(user);
            _service.SaveChanges();

            return Ok();
        }
    }
}