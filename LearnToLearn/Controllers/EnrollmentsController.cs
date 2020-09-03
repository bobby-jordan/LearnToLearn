using AutoMapper;
using LearnToLearn.BindingModels;
using LearnToLearn.DataAccess;
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
    public class EnrollmentsController : ApiController
    {
        private BaseRepository<Enrollments> _repository;
        private EnrollmentService _service;
        private ModelStateDictionary _modelState;

        public EnrollmentsController()
        {
            this._repository = new BaseRepository<Enrollments>();
            this._modelState = new ModelStateDictionary();
            this._service = new EnrollmentService(_modelState, _repository);
        }

        [Route("api/enrollments")]
        [ResponseType(typeof(Enrollments))]
        public IHttpActionResult GetEnrollments()
        {
            var enrollments = _service.ListEnrollments();
            var bindingModel = Mapper.Map<List<EnrollmentsBindingModels>>(enrollments);

            return Ok(bindingModel);
        }

        [Route("api/enrollments/{id}")]
        [ResponseType(typeof(Enrollments))]
        public IHttpActionResult GetEnrollment(int id)
        {
            var enrollment = _service.GetEnrollment(id);
            var bindingModel = Mapper.Map<EnrollmentsBindingModels>(enrollment);

            if (bindingModel == null)
            {
                return NotFound();
            }
            return Ok(bindingModel);
        }

        [Route("api/enrollments")]
        public IHttpActionResult Post([FromBody] EnrollmentsBindingModels enrollmentsBindingModel)
        {
            Enrollments enrollments = new Enrollments();
            var newEnrollment = Mapper.Map(enrollmentsBindingModel, enrollments);

            _service.CreateEnrollment(newEnrollment);
            _service.SaveChanges();
            return Ok();
        }

        [Route("api/enrollments/{id}")]
        public IHttpActionResult Put([FromBody] EnrollmentsBindingModels enrollmentBindingModel)
        {
            Enrollments enrollment = new Enrollments();
            var id = enrollment.Id;
            enrollment = _service.GetEnrollment(id);
            var newEnrollment = Mapper.Map(enrollmentBindingModel, enrollment);

            _service.EditEnrollment(newEnrollment);
            _service.SaveChanges();
            return Ok();
        }

        [Route("api/enrollments/{id}")]
        public IHttpActionResult DeleteEnrollment(EnrollmentsBindingModels enrollmentsBindingModel, int? id)
        {     
            var enrollment = _service.GetEnrollment(id.Value);
            var bindingModel = Mapper.Map<EnrollmentsBindingModels>(enrollment);

            if (id == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _service.DeleteEnrollment(enrollment);
            _service.SaveChanges();

            return Ok();
        }
    }
}
