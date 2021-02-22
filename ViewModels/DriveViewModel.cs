using Hangar13Test.Models;
using System.Collections.Generic;
using System.Linq;

namespace Hangar13Test.ViewModels
{
    class DriveViewModel
    {
        private IList<DirectoryViewModel> _driveList;

        public DriveViewModel()
        {
            _driveList = DirectoryService.GetRootDirectories().Select(x =>
                new DirectoryViewModel
                {
                    Name = x.Name,
                    FilePath = x.Name
                }
            ).ToList();
        }

        public IList<DirectoryViewModel> Drives
        {
            get { return _driveList; }
            set { _driveList = value; }
        }
    }
}
