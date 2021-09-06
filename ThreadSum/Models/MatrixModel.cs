using System;

using ThreadSum.Models.Primitives;

namespace ThreadSum.Models;
/// <summary>
/// This is a bi-dimensional matrix
/// </summary>
public class MatrixModel {
	#region Atrributes
	private Cell[,] _Values;
	#endregion
	#region Properties
	/// <summary>
	/// Gets the row size of the matrix
	/// </summary>
	public int RowCount {
		get; private set;
	}
	/// <summary>
	/// Gets the column size of the matrix
	/// </summary>
	public int ColumnCount {
		get; private set;
	}
	#endregion
	#region Constructors
	/// <summary>
	/// Creates a matrix
	/// </summary>
	/// <param name="rowCount">Row size</param>
	/// <param name="columnCount">Column size</param>
	public MatrixModel(int rowCount, int columnCount) {
		this._Values = new Cell[this.RowCount = rowCount, this.ColumnCount = columnCount];
		Random random = new();
		for (int row = 0; row < rowCount; row++) {
			for (int column = 0; column < columnCount; column++) {
				this._Values[row, column] = new(random.Next(1, rowCount + columnCount));
			}
		}
	}
	#endregion
	#region Indexers
	/// <summary>
	/// Gets a cell from the matrix
	/// </summary>
	/// <param name="row">Row index</param>
	/// <param name="column">Column index</param>
	/// <returns>Cell</returns>
	public Cell this[int row, int column] {
		get => this._Values[row, column];
		set => this._Values[row, column] = value;
	}
	#endregion
}
