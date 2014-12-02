using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace DataLayer
{
    public interface IRepository<T> where T : class
    {
        List<T> GetObjects();

        int AddObject(T obj);
    }
}