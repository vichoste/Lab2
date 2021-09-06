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
	public async void Summation_Click(object sender, RoutedEventArgs e) {
		SummationViewModel? summationViewModel = (SummationViewModel) this.TotalsGrid.DataContext;
		CellViewModel cellViewModel = (CellViewModel) this.ValuesGrid.DataContext;
		if (!summationViewModel.IsDone) {
			int total = 0;
			for (int row = 0; row < 10; row++) {
				await Task.Run(() => SumRowValues(row, summationViewModel, cellViewModel));
				total += summationViewModel[row];
			}
			Total(summationViewModel, total);
		}
	}
	private static async void SumRowValues(int row, SummationViewModel summationViewModel, CellViewModel cellViewModel) {
		for (int column = 0; column < 10; column++) {
			_ = await Task.Run(() => summationViewModel[row] += cellViewModel[row, column]);
			await Task.Delay(TimeSpan.FromMilliseconds(250));
		}
	}
	private static void Total(SummationViewModel summationViewModel, int total) {
		summationViewModel[10] = total;
		summationViewModel.IsDone = true;
	}
}
