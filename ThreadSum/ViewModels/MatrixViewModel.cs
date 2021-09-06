using System.ComponentModel;
using System.Runtime.CompilerServices;

using ThreadSum.Models;
using ThreadSum.Models.Primitives;

namespace ThreadSum.ViewModels;
/// <summary>
/// View Model for Matrix
/// </summary>
public class MatrixViewModel : INotifyPropertyChanged {
	#region Attributes
	private MatrixModel _MatrixModel;
	#endregion
	#region Constructors
	/// <summary>
	/// Creates a view model for a matrix
	/// </summary>
	/// <param name="rowCount">Row size</param>
	/// <param name="columnCount">Column size</param>
	public MatrixViewModel(int rowCount, int columnCount) => this._MatrixModel = new(rowCount, columnCount);
	#endregion
	#region Indexers
	/// <summary>
	/// Gets a cell from the matrix
	/// </summary>
	/// <param name="row">Row index</param>
	/// <param name="column">Column index</param>
	/// <returns>Cell</returns>
	[IndexerName("Cell")]
	public Cell this[int row, int column] {
		get => this._MatrixModel[row, column];
		set {
			this._MatrixModel[row, column] = value;
			this.OnPropertyChanged($"Cell[{row}, {column}]");
		}
	}
	#endregion
	#region Events
	public event PropertyChangedEventHandler? PropertyChanged;
	public void OnPropertyChanged(string value) => this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(value));
	#endregion
}
