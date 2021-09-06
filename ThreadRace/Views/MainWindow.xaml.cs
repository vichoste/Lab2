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
				int dx = random.Next(1, 2);
				int nextStep = column + dx > 100 ? 1 : dx;
				if (column + nextStep < 100) {
					if (column is not 30 and not 60 and not 90) {
						racerViewModel[row, column + nextStep] = new() {
							HasBaton = true,
							IsARacer = true
						};
						for (int i = column + nextStep - 1; i >= column; i--) {
							racerViewModel[row, i] = new() {
								HasBaton = false,
								IsARacer = false
							};
						}
					} else {
						racerViewModel[row, column] = new() {
							HasBaton = false,
							IsARacer = true
						};
					}
				}
				await Task.Delay(30);
			}
		}
	}
	#endregion
}