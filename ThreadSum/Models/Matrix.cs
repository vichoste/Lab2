using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ThreadSum.Models;
internal class Matrix : INotifyPropertyChanged {
	private readonly int[,] _Array;
	public Matrix(int size) => this._Array = new int[size, size];
	[IndexerName("Position")]
	public int this[int row, int column] {
		get => this._Array[row, column];
		set {
			this._Array[row, column] = value;
			this.OnPropertyChanged($"Position[{row}, {column}]");
		}
	}

	public event PropertyChangedEventHandler? PropertyChanged;

	public void OnPropertyChanged(string name) => this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}