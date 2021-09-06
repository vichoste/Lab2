using System;

using ThreadSum.Models.Primitives;

namespace ThreadSum.Models;
/// <summary>
/// This is a bi-dimensional matrix
/// </summary>
public class MatrixModel {
	private Cell[,] _Values;
	public int RowCount {
		get; private set;
	}
	public int ColumnCount {
		get; private set;
	}
	public MatrixModel(int rowCount, int columnCount) {
		this._Values = new Cell[this.RowCount = rowCount, this.ColumnCount = columnCount];
		Random random = new();
		for (int row = 0; row < rowCount; row++) {
			for (int column = 0; column < columnCount; column++) {
				this._Values[row, column] = new(random.Next(1, rowCount + columnCount));
			}
		}
	}
	public Cell this[int row, int column] {
		get => this._Values[row, column];
		set => this._Values[row, column] = value;
	}
}
