using System.ComponentModel;
using System.Runtime.CompilerServices;

using ThreadSum.Models;
using ThreadSum.Models.Primitives;

namespace ThreadSum.ViewModels;
internal class MatrixViewModel : INotifyPropertyChanged {
	private MatrixModel _MatrixModel;
	private int _RowCount;
	private int _ColumnCount;
	public MatrixViewModel(int rowCount, int columnCount) => this._MatrixModel = new(this._RowCount = rowCount, this._ColumnCount = columnCount);
	[IndexerName("Cell")]
	public Cell this[int row, int column] {
		get => this._MatrixModel[row, column];
		set {
			this._MatrixModel[row, column] = value;
			this.OnPropertyChanged($"Cell[{row}, {column}]");
		}
	}
	public event PropertyChangedEventHandler? PropertyChanged;
	public void OnPropertyChanged(string value) => this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(value));
}
