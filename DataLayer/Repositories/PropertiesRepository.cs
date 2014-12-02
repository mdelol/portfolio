using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Achievments;

namespace DataLayer.Repositories
{
    class PropertiesRepository : IRepository<AchievmentPropertyType>
    {
        private static PropertiesRepository _repository;

        private AchievmentContext _db = new AchievmentContext();

        private PropertiesRepository()
        {

        }

        public static PropertiesRepository GetInstance()
        {
            return _repository ?? (_repository = new PropertiesRepository());
        }
        public List<AchievmentPropertyType> GetObjects()
        {
            lock (_db)
            {
                return _db.PropertyTypes.ToList();
            }
        }

        public int AddObject(AchievmentPropertyType obj)
        {
            lock (_db)
            {
                _db.PropertyTypes.Add(obj);
                return _db.SaveChanges();
            }
        }

        public int AddRange(List<AchievmentPropertyType> objects)
        {
            lock (_db)
            {
                _db.PropertyTypes.AddRange(objects);
                return _db.SaveChanges();
            }
        }
    }
}
