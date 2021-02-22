using Hangar13Test.ViewModels;
using System.IO;
using System.Windows;

namespace Hangar13Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
	{
		private readonly DriveViewModel _viewModel;

		public MainWindow()
		{
			InitializeComponent();

			_viewModel = new DriveViewModel();
			DataContext = _viewModel;
		}
	}
}
