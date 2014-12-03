using System;
using System.Collections.Generic;

namespace DataLayer.Repositories
{
    public abstract class BaseRepository<T>:IDisposable where T : class
    {
        protected AchievmentContext _db = new AchievmentContext();

        public abstract List<T> GetObjects();

        public abstract int AddObject(T obj);

        public abstract int AddRange(IEnumerable<T> objects);
        public void Dispose()
        {
            _db.Dispose();
        }
    }
}