using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Commands;
using Commands.Filters;
using Models.Commands;
using Models.Commands.Filters;

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

                PrepareTypes(command.Filters.OfType<TypeFilter>());

                foreach (var complexFilter in command.Filters.OfType<ComplexFilter>())
                {
                    PrepareTypes(complexFilter.Filters.OfType<TypeFilter>());
                }
                _db.Commands.Add(command);
                return _db.SaveChanges();
            }
        }

        private static void PrepareTypes(IEnumerable<TypeFilter> filters)
        {
            foreach (var typeFilter in filters)
            {
                typeFilter.Type =
                    _db.PropertyTypes.First(x => x.AchievmentPropertyTypeId == typeFilter.Type.AchievmentPropertyTypeId);
            }
        }

        public override int AddRange(IEnumerable<Command> objects)
        {
            lock (_db)//TODO сделать как в добавлении единичного объекта
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
                PrepareTypes(obj.Filters.OfType<TypeFilter>());
                foreach (var complexFilter in obj.Filters.OfType<ComplexFilter>())
                {
                    PrepareTypes(complexFilter.Filters.OfType<TypeFilter>());
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
