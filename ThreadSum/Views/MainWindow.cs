using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
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
			List<Task>? rowResults = new();
			for (int row = 0; row < 10; row++) {
				rowResults.Add(SumRowValues(row, summationViewModel, cellViewModel));
			}
			await Task.WhenAll(rowResults);
			summationViewModel[10] = total;
			summationViewModel.IsDone = true;
		}
	}
	private static async Task<int> SumRowValues(int row, SummationViewModel summationViewModel, CellViewModel cellViewModel) {
		for (int column = 0; column < 10; column++) {
			summationViewModel[row] += cellViewModel[row, column];
			await Task.Delay(1000);
		}
		return summationViewModel[row];
	}
}
