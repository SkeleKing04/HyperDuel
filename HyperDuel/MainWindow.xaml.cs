using System;
using System.Collections.Generic;
using System.IO;
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

namespace HyperDuel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            if (variables.playerName[0] == null)
            {
                CSButton.IsEnabled = false;
            }
            else
            {
                CSButton.IsEnabled = true;
            }
        }
        private void helpButton_Click(object sender, RoutedEventArgs e)
        {
            new helpPage().Show();
            Close();
        }

        private void CSButton_click(object sender, RoutedEventArgs e)
        {
            new CharaSelPage().Show();
            Close();
        }

        private void CCButton_Click(object sender, RoutedEventArgs e)
        {
            new CaCPage().Show();
            Close();
        }

        private void quitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
