using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

using ThreadRace.Models;
using ThreadRace.ViewModels;

namespace ThreadRace.Views;
/// <summary>
/// Main window
/// </summary>
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
	public void Reset_Click(object sender, RoutedEventArgs e) {
		RacerViewModel racerViewModel = new();
		this.FirstRaceTrack.DataContext = this.SecondRaceTrack.DataContext = racerViewModel;
		this.Reset.IsEnabled = this.Go.IsEnabled = true;
	}
	/// <summary>
	/// Do the summation
	/// </summary>
	public async void Go_Click(object sender, RoutedEventArgs e) {
		this.Reset.IsEnabled = this.Go.IsEnabled = false;
		RacerViewModel? racerViewModel = (RacerViewModel) this.FirstRaceTrack.DataContext;
		if (!racerViewModel.IsDone) {
			List<Task>? rowResults = new();
			for (int row = 0; row < 2; row++) {
				rowResults.Add(this.GoRaceTrack(row));
			}
			await Task.WhenAll(rowResults);
			racerViewModel.IsDone = true;
		}
		this.Reset.IsEnabled = true;
	}
	#endregion
	#region Methods
	/// <summary>
	/// Sums the row values
	/// </summary>
	/// <param name="row">Row</param>
	/// <returns>Async task result</returns>
	private async Task GoRaceTrack(int row) {
		RacerViewModel? racerViewModel = (RacerViewModel) this.FirstRaceTrack.DataContext;
		for (int column = 0; column < 100; column++) {
			if (racerViewModel[row, column] is RacerModel currentRacer) {
				Random random = new();
				int nextStep = random.Next(1, 3);
				if (column + nextStep < 100) {
					racerViewModel[row, column] = new(currentRacer.Position + nextStep) {
						HasBaton = false,
						IsARacer = false
					};
					racerViewModel[row, column + nextStep] = new(currentRacer.Position + nextStep) {
						HasBaton = true,
						IsARacer = true
					};
				}
			}
		}
		await Task.Delay(60);
	}
	#endregion
}