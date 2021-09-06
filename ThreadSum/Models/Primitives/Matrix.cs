using System.Collections;
using System.Collections.Generic;
using System.Windows.Documents;
using System.Linq;

namespace ThreadSum.Models.Primitives;
/// <summary>
/// This is a bi-dimensional matrix
/// </summary>
internal class Matrix {
	private Cell[,] _Values;
	public int RowCount {
		get; private set;
	}
	public int ColumnCount {
		get; private set;
	}
	public IEnumerable<List<Cell>> Rows {
		get {
			for (int i = 0; i < this.RowCount; i++) {
				yield return new List<Cell>(Enumerable.Range(0, this.ColumnCount).Select(x => this._Values[x, this.ColumnCount]).ToList());
			}
		}
	} 
	public Matrix(int size) => this._Values = new Cell[this.RowCount = size, this.ColumnCount = size];
}
