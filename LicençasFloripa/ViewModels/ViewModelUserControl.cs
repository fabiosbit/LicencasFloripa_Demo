using System.ComponentModel;

namespace LicençasFloripa
{
    public class ViewModelUserControl : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private object _view;
        public object View
        {
            get
            {
                if (_view == null)
                {
                    return null;
                }
                return _view;
            }
            set
            {
                _view = value;
                OnPropertyChanged("View");
            }
        }
    }
}
