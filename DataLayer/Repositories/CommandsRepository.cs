using System.Collections.Generic;
using System.Linq;
using Commands;

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
                _db.Commands.Add(command);
                return _db.SaveChanges();
            }
        }

        public override int AddRange(IEnumerable<Command> objects)
        {
            lock (_db)
            {
                _db.Commands.AddRange(objects);
                return _db.SaveChanges();
            }
        }

        public override int UpdateOrAddObject(Command obj)
        {
            if (!_db.Commands.Any(x => x.CommandId == obj.CommandId))
            {
                _db.Commands.Add(obj);
            }
            return _db.SaveChanges();
        }
    }
}
