using System.Collections.Generic;

namespace DataLayer.Repositories
{
    public interface IRepository<T> where T : class
    {
        List<T> GetObjects();

        int AddObject(T obj);

        int AddRange(List<T> objects);
    }
}