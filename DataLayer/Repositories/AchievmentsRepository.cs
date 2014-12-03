using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Achievments;

namespace DataLayer.Repositories
{
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
    }
}
