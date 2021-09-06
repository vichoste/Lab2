using System;
using System.Collections.Generic;
using System.ComponentModel;

using ThreadSum.Models;

namespace ThreadSum.ViewModels;
/// <summary>
/// This is a bi-dimensional matrix
/// </summary>
public class CellViewModel : INotifyPropertyChanged {
	#region Atrributes
	private CellModel[,] _Values;
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
	/// <summary>
	/// Gets the rows with their respective values
	/// </summary>
	public List<CellModel> Values {
		get {
			List<CellModel> values = new();
			for (int row = 0; row < this.RowCount; row++) {
				for (int column = 0; column < this.ColumnCount; column++) {
					values.Add(this._Values[row, column]);
				}
			}
			return values;
		}
	}
	#endregion
	#region Constructors
	/// <summary>
	/// Creates a default view model for a 10x10 matrix
	/// </summary>
	public CellViewModel() {
		this._Values = new CellModel[this.RowCount = 10, this.ColumnCount = 10];
		Random random = new();
		for (int row = 0; row < 10; row++) {
			for (int column = 0; column < 10; column++) {
				this._Values[row, column] = new(random.Next(1, 20));
			}
		}
	}
	#endregion
	#region Indexers
	/// <summary>
	/// Gets or sets a value inside the cell
	/// </summary>
	/// <param name="row">Row index</param>
	/// <param name="column">Column index</param>
	/// <returns>Value at the position</returns>
	public int this[int row, int column] {
		get {
			this._Values[row, column].IsUsed = true;
			this.OnPropertyChanged("Values");
			return this._Values[row, column].Value;
		}
		set {
			this._Values[row, column].Value = value;
			this.OnPropertyChanged("Values");
		}
	}
	#endregion
	#region Events
	/// <summary>
	/// Property changed event handler
	/// </summary>
	public event PropertyChangedEventHandler? PropertyChanged;
	/// <summary>
	/// When property changes, call this function
	/// </summary>
	/// <param name="value">Property name</param>
	public void OnPropertyChanged(string value) => this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(value));
	#endregion
}