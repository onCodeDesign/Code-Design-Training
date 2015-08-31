using System.Windows;
using Contracts.Location;
using Microsoft.Practices.ServiceLocation;

namespace WpfApplication
{
	/// <summary>
	///     Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			ILocationService service = ServiceLocator.Current.GetInstance<ILocationService>();
			service.GetCoordinates("some city", "street name", "house number");
		}
	}
}