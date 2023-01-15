using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace LongoToDo.Core.ViewModels
{
	public class BaseViewModel : INotifyPropertyChanged
	{
        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual async Task InitializeAsync(object navigationData)
        {
        }
    }
}

