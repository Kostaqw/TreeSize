using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TreeSize.Service.Service;
using TreeSize.Ui.Context;
using TreeSize.Ui.ViewModel;

namespace TreeSize.Ui
{

    public partial class MainWindow : Window
    {
        ViewModelContext context;
        public MainWindow()
        {
            InitializeComponent();
            context = new ViewModelContext("");
        }

        private void show_Click(object sender, RoutedEventArgs e)
        {
            tree.ItemsSource = context.viewNodes;
        }

        private void OpenFolder_click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var vn = button.DataContext as ViewNode;
            context.AddInNode(vn.FullName, vn);
        }
    }
}
