using System.Collections.Generic;
using System.ComponentModel;

using ThreadRace.Models;

namespace ThreadRace.ViewModels;
/// <summary>
/// We are on the race track (8)
/// </summary>
public class RacerViewModel : INotifyPropertyChanged {
	#region Attributes
	private RacerModel?[,] _RaceTrack;
	#endregion
	#region Properties
	/// <summary>
	/// Gets the first race track
	/// </summary>
	public List<RacerModel> FirstRaceTrack {
		get {
			List<RacerModel> racers = new();
			for (int column = 0; column < this.ColumnCount; column++) {
				if (this._RaceTrack[0, column] is RacerModel racerModel) {
					racers.Add(racerModel);
				}
			}
			return racers;
		}
	}
	/// <summary>
	/// Gets the second race track
	/// </summary>
	public List<RacerModel> SecondRaceTrack {
		get {
			List<RacerModel> racers = new();
			for (int column = 0; column < this.ColumnCount; column++) {
				if (this._RaceTrack[1, column] is RacerModel racerModel) {
					racers.Add(racerModel);
				}
			}
			return racers;
		}
	}
	/// <summary>
	/// Gets the row size of the race track
	/// </summary>
	public int RowCount {
		get; private set;
	}
	/// <summary>
	/// Gets the column size of the race track
	/// </summary>
	public int ColumnCount {
		get; private set;
	}
	#endregion
	#region Constructors
	/// <summary>
	/// Creates a default race track model with racers
	/// </summary>
	public RacerViewModel() {
		this._RaceTrack = new RacerModel[this.RowCount = 2, this.ColumnCount = 100];
		for (int row = 0; row < this.RowCount; row++) {
			for (int column = 0; column < this.ColumnCount; column++) {
				if (column is 0 or 30 or 60 or 90) {
					this._RaceTrack[row, 0] = new RacerModel() {
						HasBaton = true,
						IsARacer = true
					};
					this._RaceTrack[row, 30] = new RacerModel() {
						HasBaton = false,
						IsARacer = true
					};
					this._RaceTrack[row, 60] = new RacerModel() {
						HasBaton = false,
						IsARacer = true
					};
					this._RaceTrack[row, 90] = new RacerModel() {
						HasBaton = false,
						IsARacer = true
					};
				} else {
					this._RaceTrack[row, column] = new RacerModel() {
						HasBaton = false,
						IsARacer = false
					};
				}
			}
		}
	}
	#endregion
	#region Indexers
	/// <summary>
	/// Gets or sets a value inside the cell
	/// </summary>
	/// <param name="row">Row index</param>
	/// <param name="column">Column index</param>
	/// <returns>Value at the position</returns>
	public RacerModel? this[int row, int column] {
		get {
			this.OnPropertyChanged("FirstRaceTrack");
			this.OnPropertyChanged("SecondRaceTrack");
			return this._RaceTrack[row, column];
		}
		set {
			this._RaceTrack[row, column] = value;
			this.OnPropertyChanged("FirstRaceTrack");
			this.OnPropertyChanged("SecondRaceTrack");
		}
	}
	#endregion
	#region Events
	/// <summary>
	/// Property changed event handler
	/// </summary>
	public event PropertyChangedEventHandler? PropertyChanged;
	/// <summary>
	/// When property changes, call this function
	/// </summary>
	/// <param name="value">Property name</param>
	public void OnPropertyChanged(string value) => this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(value));
	#endregion
}