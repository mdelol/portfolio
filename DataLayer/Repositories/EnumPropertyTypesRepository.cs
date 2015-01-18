using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Achievments.AchievmentProperties;

namespace DataLayer.Repositories
{
    /// <summary>
    /// репозиторий типов enum-свойств
    /// </summary>
    public class EnumPropertyTypesRepository : BaseRepository<EnumPropertyType>
    {
        private static EnumPropertyTypesRepository _repository;

        private AchievmentContext _db = new AchievmentContext();

        private EnumPropertyTypesRepository()
        {

        }

        public static EnumPropertyTypesRepository GetInstance()
        {
            return _repository ?? (_repository = new EnumPropertyTypesRepository());
        }

        public override List<EnumPropertyType> GetObjects()
        {
            lock (_db)
            {
                return _db.EnumPropertyTypes.ToList();
            }
        }

        public override int AddObject(EnumPropertyType obj)
        {
            lock (_db)
            {
                _db.EnumPropertyTypes.Add(obj);
                return _db.SaveChanges();
            }
        }

        public override int AddRange(IEnumerable<EnumPropertyType> objects)
        {
            lock (_db)
            {
                _db.EnumPropertyTypes.AddRange(objects);
                return _db.SaveChanges();
            }
        }

        public override int UpdateOrAddObject(EnumPropertyType obj)
        {
            if (!_db.EnumPropertyTypes.Any(x => x.EnumPropertyTypeId == obj.EnumPropertyTypeId))
            {
                _db.EnumPropertyTypes.Add(obj);
            }
            return _db.SaveChanges();
        }

        public override int DeleteObject(EnumPropertyType obj)
        {
            _db.EnumPropertyTypes.Remove(obj);
            return _db.SaveChanges();
        }
    }
}