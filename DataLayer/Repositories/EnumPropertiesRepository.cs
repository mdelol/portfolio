using System.Collections.Generic;
using System.Linq;
using Achievments.AchievmentProperties;

namespace DataLayer.Repositories
{
    public class EnumPropertiesRepository : IRepository<EnumProperty>
    {
        private static EnumPropertiesRepository _repository;

        private AchievmentContext _db = new AchievmentContext();

        private EnumPropertiesRepository()
        {

        }

        public static EnumPropertiesRepository GetInstance()
        {
            return _repository ?? (_repository = new EnumPropertiesRepository());
        }

        public List<EnumProperty> GetObjects()
        {
            lock (_db)
            {
                return _db.EnumProperties.ToList();
            }
        }

        public int AddObject(EnumProperty obj)
        {
            lock (_db)
            {
                _db.EnumProperties.Add(obj);
                return _db.SaveChanges();
            }
        }

        public int AddRange(List<EnumProperty> objects)
        {
            lock (_db)
            {
                _db.EnumProperties.AddRange(objects);
                return _db.SaveChanges();
            }
        }
    }
}