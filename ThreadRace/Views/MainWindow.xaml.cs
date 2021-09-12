using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

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
		if (this.FirstRaceTrack.DataContext is RacerViewModel firstTrack && this.SecondRaceTrack.DataContext is RacerViewModel secondTrack) {
			List<Task>? rowResults = new();
			rowResults.Add(GoRaceTrack(firstTrack, 0));
			rowResults.Add(GoRaceTrack(secondTrack, 1));
			await Task.WhenAll(rowResults);
			this.Reset.IsEnabled = true;
		}
	}
	#endregion
	#region Methods
	/// <summary>
	/// Starts the race
	/// </summary>
	/// <param name="racerViewModel">Race view model</param>
	/// <param name="row">Race track</param>
	/// <returns>Race track async task</returns>
	private static async Task GoRaceTrack(RacerViewModel racerViewModel, int row) {
		for (var column = 0; column < 100; column++) {
			if (racerViewModel[row, column] is not null) {
				Random random = new();
				var dx = random.Next(1, 2);
				var nextStep = column + dx > 100 ? 1 : dx;
				if (column + nextStep < 100) {
					if (column is not 30 and not 60 and not 90) {
						racerViewModel[row, column + nextStep] = new() {
							HasBaton = true,
							IsARacer = true
						};
						for (var i = column + nextStep - 1; i >= column; i--) {
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