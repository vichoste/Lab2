using System.Windows;

using ThreadSum.ViewModels;

namespace ThreadSum.Views;

public partial class MainWindow : Window {
	public MainWindow() => this.InitializeComponent();
	public void Generate_Click(object sender, RoutedEventArgs e) => this.DataContext = new CellViewModel();
}
