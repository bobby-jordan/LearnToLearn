using LearnToLearn.Models;
using System;
using System.Collections.Generic;

namespace LearnToLearn.Repositories
{
    public interface IBaseRepository<T> : IDisposable where T : BaseModel
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(T obj);
        void Save();
    }
}