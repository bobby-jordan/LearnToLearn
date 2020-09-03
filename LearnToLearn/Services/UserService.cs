using LearnToLearn.Models;
using LearnToLearn.Repositories;
using System.Collections.Generic;
using System.Web.Http.ModelBinding;
using System;

namespace LearnToLearn.Services
{
    public class UserService : IUserService
    {
        private ModelStateDictionary _modelState;
        private BaseRepository<Users> _repository;

        public UserService(ModelStateDictionary modelState, BaseRepository<Users> repository)
        {
            _modelState = modelState;
            _repository = new BaseRepository<Users>();
        }

        public Users GrantResourceOwnerCredentials(string username, string password)
        {
            foreach(var user in _repository.GetAll()) {
                if (user.Name == username && user.Password == password)
                    return user;
            }

            return new Users();
        }

        protected bool ValidateUser(Users userToValidate)
        {
            if (userToValidate.Name.Trim().Length == 0)
                _modelState.AddModelError("Name", "Name is required.");
            if (userToValidate.Email.Trim().Length == 0)
                _modelState.AddModelError("Email", "Email is required.");
            if (userToValidate.Password.Trim().Length == 0 )
                _modelState.AddModelError("Password", "Password is required.");
            if (userToValidate.IsTeacher == false)
                _modelState.AddModelError("Password", "Password is required.");
            return _modelState.IsValid;
        }

        public IEnumerable<Users> ListUsers()
        {
            return _repository.GetAll();
        }

        public Users GetUser(int id)
        {
           return _repository.GetById(id);
        }

        public void EditUser(Users obj)
        {
            _repository.Update(obj);
        }

        public void DeleteUser(Users obj)
        {
            _repository.Delete(obj);
        }

        public void SaveChanges()
        {
            _repository.Save();
        }

        public void CreateUser(Users userToCreate)
        {
            _repository.Insert(userToCreate);  
        }   
    }
    public interface IUserService
    {
        void CreateUser(Users userToCreate);
        IEnumerable<Users> ListUsers();
    }
}