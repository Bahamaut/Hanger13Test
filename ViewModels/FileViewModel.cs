namespace Hangar13Test
{
    public class FileViewModel
    {
        private DirectoryViewModel _parent;

        public FileViewModel()
        {
            _parent = null;
        }

        public FileViewModel(DirectoryViewModel parent)
        {
            _parent = parent;
        }

        public string Name { get; set; }
        public string FilePath { get; set; }
        public bool IsSelected { get; set; }
        public bool IsExpanded { get; set; }
        DirectoryViewModel Parent { get { return _parent; } }
    }
}
