using LearnToLearn.DataAccess;
using LearnToLearn.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LearnToLearn.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        protected LearnToLearnContext _db;
        protected DbSet<T> _table;

        public BaseRepository()
        {
            this._db = new LearnToLearnContext();
            _table = _db.Set<T>();
        }

        public BaseRepository(LearnToLearnContext db)
        {
            this._db = db;
            _table = db.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _table.ToList();
        }

        public T GetById(int id)
        {
            return _table.Find(id);
        }

        public void Insert(T obj)
        {
            _table.Add(obj);
        }

        public void Update(T obj)
        {
            _table.Attach(obj);
            _db.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(T obj)
        {
            _table.Remove(obj);
        }

        public void Save()
        {
             _db.SaveChanges();
        }

            #region IDisposable Support
            private bool disposedValue = false; 

            protected virtual void Dispose(bool disposing)
            {
                if (!disposedValue)
                {
                    if (disposing)
                    {
                        _db.Dispose();
                    }

                    disposedValue = true;
                }
            }
            public void Dispose()
            {
                Dispose(true);

            }
        #endregion
    }
}
