﻿using System;
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
	/// Gets the rows
	/// </summary>
	public List<CellModel> Values {
		get {
			List<CellModel> values = new();
			for (int i = 0; i < this.RowCount; i++) {
				for (int j = 0; j < this.ColumnCount; j++) {
					values.Add(this._Values[i, j]);
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
	#region Events
	public event PropertyChangedEventHandler? PropertyChanged;
	public void OnPropertyChanged(string value) => this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(value));
	#endregion
}
