using System;
using System.Collections.Generic;

namespace DataLayer.Repositories
{
    /// <summary>
    /// базовый репозиторий. наследники должны быть синглтонами для обеспечения потокобезопасности
    /// </summary>
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