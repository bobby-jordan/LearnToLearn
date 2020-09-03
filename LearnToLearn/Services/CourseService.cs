using LearnToLearn.Models;
using LearnToLearn.Repositories;
using System.Collections.Generic;
using System.Web.Http.ModelBinding;

namespace LearnToLearn.Services
{
    public class CourseService 
    {
        private ModelStateDictionary _modelState;
        private BaseRepository<Courses> _repository;

        public CourseService(ModelStateDictionary modelState, BaseRepository<Courses> repository)
        {
            _modelState = modelState;
            _repository = new BaseRepository<Courses>();
        }

        protected bool ValidateCourse(Courses courseToValidate)
        {
            if (courseToValidate.Name.Trim().Length == 0)
                _modelState.AddModelError("Name", "Name is required.");
            if (courseToValidate.Description.Trim().Length == 0)
                _modelState.AddModelError("Description", "Description is required.");
            if (courseToValidate.TeacherId == 0)
                _modelState.AddModelError("TeacherId", "TeacherId is required.");
            if (courseToValidate.IsVisible == false)
                _modelState.AddModelError("IsVisible", "The course is not visible now");
            if (courseToValidate.Capacity == 0)
                _modelState.AddModelError("Capacity", "Capacity is required");
            if (courseToValidate.CreatedAt == null)
                _modelState.AddModelError("CreatedAt", "CreatedAt is required.");
            if (courseToValidate.UpdatedAt == null)
                _modelState.AddModelError("UpdatedAt", "UpdatedAt is required.");
            return _modelState.IsValid;
        }

        public IEnumerable<Courses> ListCourses()
        {
            return _repository.GetAll();
        }

        public Courses GetCourse(int id)
        {
            return _repository.GetById(id);
        }

        public void EditCourse(Courses obj)
        {
            _repository.Update(obj);
        }

        public void DeleteCourse(Courses obj)
        {
            _repository.Delete(obj);
        }

        public void SaveChanges()
        {
            _repository.Save();
        }

        public void CreateCourse(Courses courseToCreate)
        {
            _repository.Insert(courseToCreate);
        }
    }

    public interface ICoursesService
    {
        bool CreateCourse(Courses courseToCreate);
        IEnumerable<Courses> ListCourses();
    }
}