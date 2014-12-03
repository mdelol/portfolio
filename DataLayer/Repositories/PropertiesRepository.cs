using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Achievments;

namespace DataLayer.Repositories
{
    class PropertiesRepository : BaseRepository<AchievmentPropertyType>
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
        public override List<AchievmentPropertyType> GetObjects()
        {
            lock (_db)
            {
                return _db.PropertyTypes.ToList();
            }
        }

        public override int AddObject(AchievmentPropertyType obj)
        {
            lock (_db)
            {
                _db.PropertyTypes.Add(obj);
                return _db.SaveChanges();
            }
        }

        public override int AddRange(IEnumerable<AchievmentPropertyType> objects)
        {
            lock (_db)
            {
                _db.PropertyTypes.AddRange(objects);
                return _db.SaveChanges();
            }
        }
    }
}
