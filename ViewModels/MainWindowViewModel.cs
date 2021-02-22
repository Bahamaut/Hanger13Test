using Hangar13Test.Models;
using System.ComponentModel;

namespace Hangar13Test.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private FolderInfo folderInfo;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
