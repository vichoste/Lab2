using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

using ThreadSum.ViewModels;

namespace ThreadSum.Views;
public partial class MainWindow : Window {
	public MainWindow() => this.InitializeComponent();
	/// <summary>
	/// Generate new data
	/// </summary>
	public void Generate_Click(object sender, RoutedEventArgs e) {
		this.ValuesGrid.DataContext = new CellViewModel();
		this.TotalsGrid.DataContext = new SummationViewModel();
	}
	/// <summary>
	/// Do the summation
	/// </summary>
	public void Summation_Click(object sender, RoutedEventArgs e) {
		SummationViewModel? summationViewModel = (SummationViewModel) this.TotalsGrid.DataContext;
		CellViewModel cellViewModel = (CellViewModel) this.ValuesGrid.DataContext;
		if (!summationViewModel.IsDone) {
			int total = 0;
			_ = Parallel.For(0, 10, i => {
				for (int j = 0; j < 10; j++) {
					summationViewModel[i] += cellViewModel[i, j];
				}
				total += summationViewModel[i];
			});
			summationViewModel[10] = total;
			summationViewModel.IsDone = true;
		}
	}
}
