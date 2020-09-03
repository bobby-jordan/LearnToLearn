using LearnToLearn.Models;
using LearnToLearn.Repositories;
using System.Collections.Generic;
using System.Web.Http.ModelBinding;

namespace LearnToLearn.Services
{
    public class EnrollmentService : IEnrollmentInterface
    {
        private ModelStateDictionary _modelState;
        private BaseRepository<Enrollments> _repository;

        public EnrollmentService(ModelStateDictionary modelState, BaseRepository<Enrollments> repository)
        {
            _modelState = modelState;
            _repository = new BaseRepository<Enrollments>();
        }

        protected bool ValidateEnrollment(Enrollments enrollmentToValidate)
        {
            if (enrollmentToValidate.UserId == 0)
                _modelState.AddModelError("UserId", "UserId is required.");
            if (enrollmentToValidate.CourseId == 0)
                _modelState.AddModelError("CourseId", "CourseId is required.");
            if (enrollmentToValidate.Grade == 0)
                _modelState.AddModelError("Grade", "Grade is required.");
            if (enrollmentToValidate.CreatedAt == null)
                _modelState.AddModelError("CreatedAt", "CreatedAt is required.");
            if (enrollmentToValidate.UpdatedAt == null)
                _modelState.AddModelError("UpdatedAt", "UpdatedAt is required.");
            return _modelState.IsValid;
        }

        public IEnumerable<Enrollments> ListEnrollments()
        {
            return _repository.GetAll();
        }

        public Enrollments GetEnrollment(int id)
        {
            return _repository.GetById(id);
        }

        public void EditEnrollment(Enrollments obj)
        {
            _repository.Update(obj);
        }

        public void DeleteEnrollment(Enrollments obj)
        {
            _repository.Delete(obj);
        }

        public void SaveChanges()
        {
            _repository.Save();
        }

        public void CreateEnrollment(Enrollments enrollmentToCreate)
        {
            _repository.Insert(enrollmentToCreate);
        }
    }

    public interface IEnrollmentInterface
    {
        void CreateEnrollment(Enrollments enrollmentToCreate);
        IEnumerable<Enrollments> ListEnrollments();
    }
}
