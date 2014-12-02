using System.Collections.Generic;
using System.Linq;
using Achievments;

namespace DataLayer
{
    public class AchievmentsRepository : IRepository<Achievment>
    {
        private static AchievmentsRepository _repository;

        private AchievmentContext _db = new AchievmentContext();

        private AchievmentsRepository()
        {

        }

        public static AchievmentsRepository GetInstance()
        {
            return _repository ?? (_repository = new AchievmentsRepository());
        }

        public List<Achievment> GetObjects()
        {
            lock (_db)
            {
                return _db.Achievments.ToList();
            }
        }

        public int AddObject(Achievment achievment)
        {
            lock (_db)
            {
                _db.Achievments.Add(achievment);
                return _db.SaveChanges();
            }
        }
    }
}
