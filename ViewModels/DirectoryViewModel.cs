using Hangar13Test.Models;
using System.Collections.Generic;
using System.ComponentModel;

namespace Hangar13Test
{
    public class DirectoryViewModel : INotifyPropertyChanged
    {
        private DirectoryViewModel _parent;
        private List<object> _children;
        private bool _isExpanded;

        public DirectoryViewModel()
        {
            _parent = null;
            _children = new List<object>();
            _children.Add("...");
            _isExpanded = false;
        }

        public DirectoryViewModel(DirectoryViewModel parent)
        {
            _parent = parent;
            _children = new List<object>();
            _children.Add("...");
            _isExpanded = false;
        }

        public string Name { get; set; }

        public string FilePath { get; set; }

        public List<object> Children { get { return _children; } }
        
        public bool HasDummyChild
        {
            get { return Children.Count == 1 && Children[0] is string && (string)Children[0]  == "..."; }
        }
        
        public bool IsExpanded
        {
            get { return _isExpanded; }
            set
            {
                if (value != _isExpanded)
                {
                    _isExpanded = value;
                    OnPropertyChanged("IsExpanded");
                }

                // Expand all the way up to the root.
                if (_isExpanded && _parent != null)
                    _parent.IsExpanded = true;

                // Lazy load the child items, if necessary.
                if (HasDummyChild)
                {
                    _children.Remove("...");
                    LoadChildren();
                }
            }
        }
        public bool IsSelected { get; set; }
        DirectoryViewModel Parent { get { return _parent; } }

        private void LoadChildren()
        {
            foreach(var directory in DirectoryService.GetChildDirectories(FilePath))
            {
                _children.Add(new DirectoryViewModel(this)
                {
                    Name = directory.Name,
                    FilePath = directory.FullName
                });
            }

            foreach (var directory in DirectoryService.GetChildFiles(FilePath))
            {
                _children.Add(new FileViewModel(this)
                {
                    Name = directory.Name,
                    FilePath = directory.FullName
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
