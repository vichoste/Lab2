using System.Collections.Generic;

using ThreadSum.Models;

namespace ThreadSum.ViewModels;
/// <summary>
/// This is for displaying the row totals and the total
/// </summary>
public class SummationViewModel {
	#region Attributes
	private List<CellModel> _RowTotals;
	#endregion
	#region Properties
	/// <summary>
	/// List of row totals
	/// </summary>
	public List<CellModel> RowTotals {
		get => new(this._RowTotals);
		private set {
		}
	}
	#endregion
	#region Constructors
	/// <summary>
	/// Creates a summation view model
	/// </summary>
	public SummationViewModel() => this._RowTotals = new() {
		new CellModel(0), // Row 0
		new CellModel(0), // Row 1
		new CellModel(0), // Row 2
		new CellModel(0), // Row 3
		new CellModel(0), // Row 4
		new CellModel(0), // Row 5
		new CellModel(0), // Row 6
		new CellModel(0), // Row 7
		new CellModel(0), // Row 8
		new CellModel(0), // Row 9
		new CellModel(0), // Row 10
		new CellModel(0), // Total
	};
	#endregion
	#region Indexers
	/// <summary>
	/// Gets or sets a value inside the row total cell
	/// </summary>
	/// <param name="row">Row index</param>
	/// <returns>Value at the index</returns>
	public int this[int row] {
		get => this._RowTotals[row].Value;
		set => this._RowTotals[row].Value = value;
	}
	#endregion
}
