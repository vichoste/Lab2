using System;
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
			for (int column = 0; row < this.ColumnCount; column += 30) {
				this._RaceTrack[row, column] = new RacerModel(column) {
					HasBaton = column == 0
				};
			}
		}
	}
	#endregion
	#region Methods
	/// <summary>
	/// Moves a racer
	/// </summary>
	/// <param name="row">Track</param>
	/// <param name="column">Racer position</param>
	public void MoveRacer(int row, int column) {
		RacerModel? currentRacer;
		if (this._RaceTrack[row, column] is RacerModel racerModel) {
			currentRacer = racerModel;
			if (currentRacer.HasBaton) {
				Random random = new();
				int nextStep = random.Next(1, 2);
				if (currentRacer.Position is >= 0 and < 30) {
					currentRacer.Position = currentRacer.Position + nextStep < 30 ? currentRacer.Position + nextStep : currentRacer.Position + 1;
				}
				this._RaceTrack[row, column] = null;
				this._RaceTrack[row, currentRacer.Position] = currentRacer;
				currentRacer.HasBaton = currentRacer.Position is not 30 and not 60 and not 90;
			}
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