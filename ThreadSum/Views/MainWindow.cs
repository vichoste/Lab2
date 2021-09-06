using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;

using ThreadSum.Models;
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
		if (!summationViewModel.IsDone) {
			var values = ( (CellViewModel) this.ValuesGrid.DataContext ).Values;
			int total = 0;
			for (int i = 0; i < 10; i++) {
				for (int j = 0; j < 10; j++) {
					summationViewModel[i] += values[i * 10 + j].Value;
				}
				total += summationViewModel[i];
			}
			summationViewModel[10] = total;
		}
	}
}
