namespace ThreadSum.Models;
/// <summary>
/// This is one cell which is part of the matrix
/// </summary>
public class CellModel {
	#region Properties
	/// <summary>
	/// Value of the cell
	/// </summary>
	public int Value {
		get; private set;
	}
	/// <summary>
	/// If this cell is added to the sum total
	/// </summary>
	public bool WasAdded {
		get; set;
	}
	#endregion
	#region Constructors
	/// <summary>
	/// Creates one cell of a matrix
	/// </summary>
	/// <param name="value">Value taken by the cell</param>
	public CellModel(int value) => this.Value = value;
	#endregion
}