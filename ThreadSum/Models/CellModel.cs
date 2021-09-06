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
		get; set;
	}
	/// <summary>
	/// Check if this cell is used
	/// </summary>
	public bool IsUsed {
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