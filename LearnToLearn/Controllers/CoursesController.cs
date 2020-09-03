using AutoMapper;
using LearnToLearn.BindingModels;
using LearnToLearn.Models;
using LearnToLearn.Repositories;
using LearnToLearn.Services;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.ModelBinding;

namespace LearnToLearn.Controllers
{
    public class CoursesController : ApiController
    {
        public BaseRepository<Courses> _repository;
        private CourseService _service;
        private ModelStateDictionary _modelState;

        public CoursesController()
        {
            this._repository = new BaseRepository<Courses>();
            this._modelState = new ModelStateDictionary();
            this._service = new CourseService(_modelState, _repository);
        }

        [Route("api/courses")]
        [ResponseType(typeof(Courses))]
        public IHttpActionResult GetCourses()
        {
            var courses = _service.ListCourses();
            var bindingModel = Mapper.Map<List<CoursesBindingModels>>(courses);

            return Ok(bindingModel);
        }

        [Route("api/courses/{id}")]
        [ResponseType(typeof(Courses))]
        public IHttpActionResult GetCourse(int id)
        {
            var courses = _service.GetCourse(id);
            var bindingModel = Mapper.Map<CoursesBindingModels>(courses);

            if (bindingModel == null)
            {
                return NotFound();
            }
            return Ok(bindingModel);
        }

        [Route("api/courses")]
        public IHttpActionResult Post([FromBody] CoursesBindingModels coursesBindingModels)
        {
            Courses course = new Courses();
            var newCourse = Mapper.Map(coursesBindingModels, course);
            _service.CreateCourse(newCourse);
            _service.SaveChanges();
            return Ok();
        }

        [Route("api/courses/{id}")]
        public IHttpActionResult Put([FromBody] CoursesBindingModels courseBindingModel)
        {
            Courses course = new Courses();
            var id = course.Id;
            course = _service.GetCourse(id);
            var newCourse = Mapper.Map(courseBindingModel, course);

            _service.EditCourse(newCourse);
            _service.SaveChanges();
            return Ok();
        }

        [Route("api/courses/{id}")]
        public IHttpActionResult DeleteCourse(CoursesBindingModels coursesBindingModel, int? id)
        {
            var course = _service.GetCourse(id.Value);
            var bindingModel = Mapper.Map<CoursesBindingModels>(course);

            if (id == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _service.DeleteCourse(course);
            _service.SaveChanges();

            return Ok();
        }
    }
}