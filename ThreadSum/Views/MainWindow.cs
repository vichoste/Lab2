using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

using ThreadSum.ViewModels;

namespace ThreadSum.Views;

/// <summary>
/// Main window
/// </summary>
public partial class MainWindow : Window {
	#region Constructors
	/// <summary>
	/// Creates the main window
	/// </summary>
	public MainWindow() => this.InitializeComponent();
	#endregion
	#region Event methods
	/// <summary>
	/// Generate new data
	/// </summary>
	public void Generate_Click(object sender, RoutedEventArgs e) {
		this.ValuesGrid.DataContext = new CellViewModel();
		this.TotalsGrid.DataContext = new SummationViewModel();
		this.Generate.IsEnabled = this.Summation.IsEnabled = true;
	}
	/// <summary>
	/// Do the summation
	/// </summary>
	public async void Summation_Click(object sender, RoutedEventArgs e) {
		this.Generate.IsEnabled = this.Summation.IsEnabled = false;
		SummationViewModel? summationViewModel = (SummationViewModel) this.TotalsGrid.DataContext;
		if (!summationViewModel.IsDone) {
			List<Task>? rowResults = new();
			for (int row = 0; row < 10; row++) {
				rowResults.Add(this.SumRowValues(row));
			}
			await Task.WhenAll(rowResults);
			summationViewModel.IsDone = true;
		}
		this.Generate.IsEnabled = true;
	}
	#endregion
	#region Methods
	/// <summary>
	/// Sums the row values
	/// </summary>
	/// <param name="row">Row</param>
	/// <returns>Async task result</returns>
	private async Task SumRowValues(int row) {
		SummationViewModel? summationViewModel = (SummationViewModel) this.TotalsGrid.DataContext;
		CellViewModel cellViewModel = (CellViewModel) this.ValuesGrid.DataContext;
		for (int column = 0; column < 10; column++) {
			summationViewModel[row] += cellViewModel[row, column];
			summationViewModel[10] += cellViewModel[row, column];
			await Task.Delay(250);
		}
	}
	#endregion
}
