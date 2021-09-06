﻿namespace ThreadRace.Models;
/// <summary>
/// This is a racer
/// </summary>
public class RacerModel {
	#region Properties
	/// <summary>
	/// Checks if this racer has the baton
	/// </summary>
	public bool HasBaton {
		get; set;
	}
	/// <summary>
	/// Check if this is actually a racer
	/// </summary>
	public bool IsARacer {
		get; set;
	}
	#endregion
	#region Constructors
	/// <summary>
	/// Creates a racer
	/// </summary>
	public RacerModel() {
	}
	#endregion
}