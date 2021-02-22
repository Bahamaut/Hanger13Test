using Hangar13Test.ViewModels;
using System.Windows;

namespace Hangar13Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
	{
		private readonly MainWindowViewModel _viewModel;

		public MainWindow()
		{
			InitializeComponent();

			_viewModel = new MainWindowViewModel();
			DataContext = _viewModel;
		}
	}
}
