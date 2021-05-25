using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HyperDuel
{
    /// <summary>
    /// Interaction logic for CharaSelPage.xaml
    /// </summary>
    public partial class CharaSelPage : Window
    {
        public CharaSelPage()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            bodyPortrait.Source = new BitmapImage(new Uri(@"/" + variables.playerGender[variables.characterNum] + variables.playerHeight[variables.characterNum] + "_PBody.png", UriKind.Relative)); //loading images into the game
            facePortrait.Source = new BitmapImage(new Uri(@"/" + variables.playerFace[variables.characterNum] + "_PFace.png", UriKind.Relative));
            hairPortrait.Source = new BitmapImage(new Uri(@"/" + variables.playerHair[variables.characterNum] + "_PHair.png", UriKind.Relative));
            hatPortrait.Source = new BitmapImage(new Uri(@"/" + variables.playerHat[variables.characterNum] + "_PHat.png", UriKind.Relative));
            battleInitiate.Content = variables.playerName[variables.characterNum];
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void battleInitiate_Click(object sender, RoutedEventArgs e)
        {
            new Window1().Show();
            Close();
        }
        private void characterNumUpBt_Click(object sender, RoutedEventArgs e)
        {
            variables.characterNum += 1;
            battleInitiate.Content = variables.playerName[variables.characterNum];
        }

        private void characterNumDownBt_Click(object sender, RoutedEventArgs e)
        {
            variables.characterNum -= 1;
            battleInitiate.Content = variables.playerName[variables.characterNum];
        }
    }
}
