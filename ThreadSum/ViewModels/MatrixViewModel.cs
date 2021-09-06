using System.ComponentModel;
using System.Runtime.CompilerServices;

using ThreadSum.Models;

namespace ThreadSum.ViewModels;
internal class MatrixViewModel : INotifyPropertyChanged {
	private MatrixModel _MatrixModel;
	public MatrixViewModel() => this._MatrixModel = new MatrixModel(100);
	[IndexerName("Position")]
	public int this[int row, int column] {
		get => this._MatrixModel[row, column];
		set {
			this._MatrixModel[row, column] = value;
			this.OnPropertyChanged($"Position[{row}, {column}]");
		}
	}
	public event PropertyChangedEventHandler? PropertyChanged;
	public void OnPropertyChanged(string name) => this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
	public IList<int> Rows {
		get {

		}
	}
}
