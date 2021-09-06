using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ThreadSum.Models;
internal class MatrixModel {
	private readonly int[,] _Array;
	public MatrixModel(int size) => this._Array = new int[size, size];
	public int this[int row, int column] {
		get => this._Array[row, column];
		set => this._Array[row, column] = value;
	}
}