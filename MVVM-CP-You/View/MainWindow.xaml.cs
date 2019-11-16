using System;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Input;

namespace MVVM_CP_You.View
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Observable.FromEventPattern<MouseButtonEventHandler, MouseButtonEventArgs>(
                    h => h.Invoke,
                    handler => this.MouseLeftButtonDown += handler,
                    handler => this.MouseLeftButtonDown -= handler)
                .Where(e => e.EventArgs.ButtonState == MouseButtonState.Pressed)
                .Subscribe(_ => this.DragMove());
        }
    }
}
