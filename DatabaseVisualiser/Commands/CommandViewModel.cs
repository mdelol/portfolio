using System.Collections.ObjectModel;
using System.Linq;
using Commands.Filters;
using DatabaseVisualiser.Commands.Filters;
using Models.Commands;
using Models.Commands.Filters;

namespace DatabaseVisualiser.Commands
{
    public class CommandViewModel
    {
        private Command _model;

        public CommandViewModel(Command model)
        {
            _model = model;
            Filters = new ObservableCollection<BaseFilter>(model.Filters);
        }

        public ObservableCollection<BaseFilter> Filters { get; set; }

        public string Name
        {
            get { return _model.Name; }
            set { _model.Name = value; }
        }

        public string ParentCommandName
        {
            get { return _model.ParentCommand == null ? string.Empty : _model.ParentCommand.Name; }
        }

        public Command GetModel()
        {
            return _model;
        }
    }
}