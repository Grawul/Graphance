using System.ComponentModel;
using System.Windows;
using Graphance.UI.ViewModels;

namespace Graphance.UI.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _fvm = new FinanceViewModel();
            DataContext = _fvm;
        }

        private readonly FinanceViewModel _fvm;






        private void MainWindow_OnClosing(object sender, CancelEventArgs e)
        {
            _fvm.Save();
        }
    }
}
