using System.ComponentModel;

namespace VisualTestApp.Common
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Событие изменения значения свойства
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Вспомогательный метод для вызова события изменения свойства
        /// </summary>
        /// <param name="propertyName">
        /// Название свойства
        /// </param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}