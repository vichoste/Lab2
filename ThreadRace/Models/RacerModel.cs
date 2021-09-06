using System;

namespace ThreadRace.Models;
/// <summary>
/// This is a racer
/// </summary>
public class RacerModel {
	#region Properties
	/// <summary>
	/// How many steps this racer can take
	/// </summary>
	public int Position {
		get; private set;
	}
	/// <summary>
	/// Checks if this racer has the baton
	/// </summary>
	public bool HasBaton {
		get; set;
	}
	#endregion
	#region Constructors
	/// <summary>
	/// Creates a racer
	/// </summary>
	public RacerModel(int position) => this.Position = position;
	#endregion
	#region Methods
	/// <summary>
	/// Makes the racer move 1 or 2 steps
	/// </summary>
	public void Run() {
		Random random = new Random();
		int dx = random.Next(1, 2);
		this.Position = this.Position + dx > 100 ? this.Position + 1 : this.Position + dx;
	}
	#endregion
}