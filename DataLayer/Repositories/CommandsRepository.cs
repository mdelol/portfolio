using System.Collections.Generic;
using System.Linq;
using Commands;
using Commands.Filters;

namespace DataLayer.Repositories
{
    public class CommandsRepository : BaseRepository<Command>
    {
        private static CommandsRepository _repository;

        private CommandsRepository()
        {

        }

        public static CommandsRepository GetInstance()
        {
            return _repository ?? (_repository = new CommandsRepository());
        }

        public override List<Command> GetObjects()
        {
            lock (_db)
            {
                return _db.Commands.ToList();
            }
        }

        public override int AddObject(Command command)
        {
            lock (_db)
            {

                foreach (var typeFilter in command.Filters.OfType<TypeFilter>())
                {
                    typeFilter.Type = _db.PropertyTypes.First(x => x.AchievmentPropertyTypeId == typeFilter.Type.AchievmentPropertyTypeId);
                }
                _db.Commands.Add(command);
                return _db.SaveChanges();
            }
        }

        public override int AddRange(IEnumerable<Command> objects)
        {
            lock (_db)
            {
                foreach (var command in objects)
                {
                    foreach (var typeFilter in command.Filters.OfType<TypeFilter>())
                    {
                        typeFilter.Type = _db.PropertyTypes.First(x => x.AchievmentPropertyTypeId == typeFilter.Type.AchievmentPropertyTypeId);
                    }
                }
                _db.Commands.AddRange(objects);
                return _db.SaveChanges();
            }
        }

        public override int UpdateOrAddObject(Command obj)
        {
            if (!_db.Commands.Any(x => x.CommandId == obj.CommandId))
            {
                foreach (var typeFilter in obj.Filters.OfType<TypeFilter>())
                {
                    typeFilter.Type = _db.PropertyTypes.First(x => x.AchievmentPropertyTypeId == typeFilter.Type.AchievmentPropertyTypeId);
                }
                _db.Commands.Add(obj);
            }
            return _db.SaveChanges();
        }

        public override int DeleteObject(Command obj)
        {
            _db.Commands.Remove(obj);
            return _db.SaveChanges();
        }
    }
}
