using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Achievments;
using Achievments.AchievmentProperties;

namespace DataLayer.Repositories
{
    /// <summary>
    /// репозиторий достижений
    /// </summary>
    public class AchievmentsRepository : BaseRepository<Achievment>
    {
        private static AchievmentsRepository _repository;

        private AchievmentsRepository()
        {

        }

        public static AchievmentsRepository GetInstance()
        {
            return _repository ?? (_repository = new AchievmentsRepository());
        }

        public override List<Achievment> GetObjects()
        {
            lock (_db)
            {
                return _db.Achievments.ToList();
            }
        }

        public override int AddObject(Achievment achievment)
        {
            lock (_db)
            {
                _db.Achievments.Add(achievment);
                return _db.SaveChanges();
            }
        }

        public override int AddRange(IEnumerable<Achievment> objects)
        {
            lock (_db)
            {
                _db.Achievments.AddRange(objects);
                return _db.SaveChanges();
            }
        }

        public override int UpdateOrAddObject(Achievment obj)
        {
            if (!_db.Achievments.Any(x => x.AchievmentId == obj.AchievmentId))
            {
                _db.Achievments.Add(obj);
            }
            return _db.SaveChanges();
        }

        public override int DeleteObject(Achievment obj)
        {
            _db.Achievments.Remove(obj);
            return _db.SaveChanges();
        }
    }
}
