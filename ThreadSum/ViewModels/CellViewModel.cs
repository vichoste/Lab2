﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

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
	/// Gets the rows
	/// </summary>
	public IEnumerable<List<CellModel>> Rows {
		get {
			for (int i = 0; i < this.RowCount; i++) {
				yield return new List<CellModel>(Enumerable.Range(0, this.ColumnCount).Select(x => this._Values[x, this.ColumnCount]).ToList());
			}
		}
	}
	#endregion
	#region Constructors
	/// <summary>
	/// Creates a matrix
	/// </summary>
	/// <param name="rowCount">Row size</param>
	/// <param name="columnCount">Column size</param>
	public CellViewModel(int rowCount, int columnCount) {
		this._Values = new CellModel[this.RowCount = rowCount, this.ColumnCount = columnCount];
		Random random = new();
		for (int row = 0; row < rowCount; row++) {
			for (int column = 0; column < columnCount; column++) {
				this._Values[row, column] = new(random.Next(1, rowCount + columnCount));
			}
		}
	}
	/// <summary>
	/// Creates a default view model for a 100x100 matrix
	/// </summary>
	public CellViewModel() {
		this._Values = new CellModel[100, 100];
		Random random = new();
		for (int row = 0; row < 100; row++) {
			for (int column = 0; column < 100; column++) {
				this._Values[row, column] = new(random.Next(1, 200));
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
	[IndexerName("Cell")]
	public CellModel this[int row, int column] {
		get => this._Values[row, column];
		set {
			this._Values[row, column] = value;
			this.OnPropertyChanged($"Cell[{row}, {column}]");
		}
	}
	#endregion
	#region Events
	public event PropertyChangedEventHandler? PropertyChanged;
	public void OnPropertyChanged(string value) => this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(value));
	#endregion
}
