using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Achievments;

namespace DataLayer.Repositories
{
    /// <summary>
    /// репозиторий типов свойств достижений
    /// </summary>
    public class PropertyTypesRepository : BaseRepository<AchievmentPropertyType>
    {
        private static PropertyTypesRepository _repository;

        private AchievmentContext _db = new AchievmentContext();

        private PropertyTypesRepository()
        {

        }

        public static PropertyTypesRepository GetInstance()
        {
            return _repository ?? (_repository = new PropertyTypesRepository());
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
