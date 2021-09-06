using System.Windows.Controls;

using ThreadSum.ViewModels;

namespace ThreadSum.Views;
public partial class Window : System.Windows.Window {
	public Window() {
		this.InitializeComponent();
		var matrixViewModel = new MatrixViewModel(100, 100);
		_ = this.Panel.Children.Add(new TextBlock() {
			Text = matrixViewModel[0, 3].Value.ToString()
		});
	}
}
