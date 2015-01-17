using System;
using System.Diagnostics;
using System.Windows.Input;

namespace VisualTestApp.Common
{
    public class RelayCommand : ICommand
    {

        /// <summary>
        /// Действие выполняемое командой
        /// </summary>
        private readonly Action<object> _execute;

        /// <summary>
        /// Проверка возможности выполнить команду
        /// </summary>
        private readonly Predicate<object> _canExecute;



        /// <summary>
        /// 
        /// </summary>
        /// <param name="text">
        /// Описание команды (отображается во всплывающей подсказке)
        /// </param>
        /// <param name="execute">
        /// Действие выполняемое командой
        /// </param>
        public RelayCommand(Action<object> execute)
            : this( execute, null)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"> </param>
        /// <param name="execute">
        /// Действие выполняемое командой
        /// </param>
        /// <param name="canExecute">
        /// Проверка возможности выполнить команду
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Для команды не установлено выполняемое действие
        /// </exception>
        public RelayCommand( Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            _execute = execute;
            _canExecute = canExecute;
        }


        /// <summary>
        /// Событие изменения состояния доступности команды для выполнения
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Проверяет можно ли выполнить команду
        /// </summary>
        /// <param name="parameter">
        /// Параметр проверки
        /// </param>
        /// <returns>
        /// true, если можно выполнить команду, иначе false
        /// </returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        /// <summary>
        /// Метод для выполнения команды
        /// </summary>
        /// <param name="parameter">
        /// Параметр команды
        /// </param>
        public void Execute(object parameter)
        {
            _execute(parameter);
        }

    }
}