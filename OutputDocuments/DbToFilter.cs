using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commands;
using Commands.Filters;
using DataLayer.Repositories;
using Models.Achievments;
using Models.Commands;


namespace OutputDocuments
{
    /// <summary>
    /// Фильтруем достижения по командам и выдаем их в виде ключ => строка (имя команды => строка из Name соответствующих достижений)
    /// </summary>
    public class DbToFilter
    {
        public static Dictionary<string, string> Filter( IEnumerable<Achievment> achievments, List<Command> commands )
        {
            var result = new Dictionary<string, string>();
            var resultCmd = new List<List<Achievment>>();
            foreach (Command command in commands)
            {
                resultCmd.Add(command.Execute(achievments).ToList());
            }
            var stringOfCmd = "";
            int i = 0;
            foreach (var dataOfCmd in resultCmd)
            {
                stringOfCmd = String.Join(", ", dataOfCmd.Select(x => x.Name));
                result.Add(commands[i].Name, stringOfCmd);
            }     
            return result;
        }
    }
}
