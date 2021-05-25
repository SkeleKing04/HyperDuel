using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// Interaction logic for CaCPage.xaml
    /// </summary>
    public partial class CaCPage : Window
    {
        public CaCPage() //initializing
        {
            InitializeComponent();
            characterImageLoad();
            setDDs();
            applyMoves();
            playerHP.Text = "HP: " + playerStats.HP[variables.characterNum].ToString();
            playerATK.Text = "ATK: " + playerStats.ATK[variables.characterNum].ToString();
            playerDEF.Text = "DEF: " + playerStats.DEF[variables.characterNum].ToString();
            playerSPD.Text = "SPD: " + playerStats.SPD[variables.characterNum].ToString();
            Int32.TryParse(currentCharacterNum.Text, out variables.characterNum);
            variables.characterNum -= 1;
        }

        private void backButton_Click(object sender, RoutedEventArgs e) //back button
        {
            new MainWindow().Show();
            Close();
        }
        private void SaveChar_Click(object sender, RoutedEventArgs e) //saving player info for other windows
        {
            if (nameBox.Text != "")
            {
                variables.playerName[variables.characterNum] = nameBox.Text;
                variables.playerClass[variables.characterNum] = classDD.Text;
                variables.playerElement[variables.characterNum] = elementDD.Text;
                variables.playerGender[variables.characterNum] = genderDD.Text;
                variables.playerHeight[variables.characterNum] = heightDD.Text;
                variables.playerFace[variables.characterNum] = faceDD.Text;
                variables.playerHair[variables.characterNum] = hairDD.Text;
                variables.playerHat[variables.characterNum] = hatDD.Text;
                variables.playerClothes[variables.characterNum] = clothesDD.Text;
                saveMoves();
                MessageBox.Show("Character \"" + nameBox.Text + "\" saved!");
            }
            else
            {
                MessageBox.Show("Error: Please enter name");
            }
        }

        private void moveUpdate(object sender, EventArgs e) //reading classDD and elementDD to update move boxes and images
        {
            applyMoves();
            saveMoves();
            characterImageLoad();
            playerHP.Text = "HP: " + playerStats.HP[variables.characterNum].ToString();
            playerATK.Text = "ATK: " + playerStats.ATK[variables.characterNum].ToString();
            playerDEF.Text = "DEF: " + playerStats.DEF[variables.characterNum].ToString();
            playerSPD.Text = "SPD: " + playerStats.SPD[variables.characterNum].ToString();
        }

        private void characterNumUpBt_Click(object sender, RoutedEventArgs e)
        {
            variables.characterNum += 1;
            int i = variables.characterNum + 1;
            currentCharacterNum.Text = i.ToString();
            setDDs();
            applyMoves();
        }

        private void characterNumDownBt_Click(object sender, RoutedEventArgs e)
        {
            variables.characterNum -= 1;
            int i = variables.characterNum + 1;
            currentCharacterNum.Text = i.ToString();
            setDDs();
            applyMoves();
        }
        private void applyMoves()
        {
            if (classDD.Text == variables.classes[0])
            {
                move2.Text = moves.all[1];
            }
            if (classDD.Text == variables.classes[1])
            {
                move2.Text = moves.all[2];
            }
            if (classDD.Text == variables.classes[2])
            {
                move2.Text = moves.all[3];
            }
            if (classDD.Text == variables.classes[3])
            {
                move2.Text = moves.all[4];
            }
            if (elementDD.Text == variables.elements[0])
            {
                move3.Text = moves.all[5];
                move3.Background = Brushes.Beige;
                move4.Background = Brushes.Beige;
            }
            if (elementDD.Text == variables.elements[1])
            {
                move3.Text = moves.all[6];
                move3.Background = Brushes.Crimson;
                move4.Background = Brushes.Crimson;
            }
            if (elementDD.Text == variables.elements[2])
            {
                move3.Text = moves.all[7];
                move3.Background = Brushes.SteelBlue;
                move4.Background = Brushes.SteelBlue;

            }
            if (elementDD.Text == variables.elements[3])
            {
                move3.Text = moves.all[8];
                move3.Background = Brushes.Green;
                move4.Background = Brushes.Green;
            }
            if (elementDD.Text == variables.elements[4])
            {
                move3.Text = moves.all[9];
                move3.Background = Brushes.Gold;
                move4.Background = Brushes.Gold;
            }
            if (elementDD.Text == variables.elements[5])
            {
                move3.Text = moves.all[10];
                move3.Background = Brushes.RosyBrown;
                move4.Background = Brushes.RosyBrown;
            }
            if (elementDD.Text == variables.elements[6])
            {
                move3.Text = moves.all[11];
                move3.Background = Brushes.MediumPurple;
                move4.Background = Brushes.MediumPurple;
            }
            if (elementDD.Text == variables.elements[7])
            {
                move3.Text = moves.all[12];
                move3.Background = Brushes.SlateGray;
                move4.Background = Brushes.SlateGray;
            }
            if (elementDD.Text == variables.elements[8])
            {
                move3.Text = moves.all[13];
                move3.Background = Brushes.DeepSkyBlue;
                move4.Background = Brushes.DeepSkyBlue;
            }
            if (elementDD.Text == variables.elements[9])
            {
                move3.Text = moves.all[14];
                move3.Background = Brushes.Purple;
                move4.Background = Brushes.Purple;
            }
            if (classDD.Text == variables.classes[0] && elementDD.Text == variables.elements[0]) //00 - Melee Basic
            {
                move4.Text = moves.all[15];
                playerStats.ATK[variables.characterNum] = 100;
                playerStats.DEF[variables.characterNum] = 150;
                playerStats.SPD[variables.characterNum] = 75;
                playerStats.HP[variables.characterNum] = 100;
            }
            if (classDD.Text == variables.classes[0] && elementDD.Text == variables.elements[1]) //01 - Melee Fire
            {
                move4.Text = moves.all[16];
                playerStats.ATK[variables.characterNum] = 125;
                playerStats.DEF[variables.characterNum] = 125;
                playerStats.SPD[variables.characterNum] = 75;
                playerStats.HP[variables.characterNum] = 100;
            }
            if (classDD.Text == variables.classes[0] && elementDD.Text == variables.elements[2]) //02 - Melee Water
            {
                move4.Text = moves.all[17];
                playerStats.ATK[variables.characterNum] = 100;
                playerStats.DEF[variables.characterNum] = 125;
                playerStats.SPD[variables.characterNum] = 100;
                playerStats.HP[variables.characterNum] = 100;
            }
            if (classDD.Text == variables.classes[0] && elementDD.Text == variables.elements[3]) // 03 - Melee Life
            {
                move4.Text = moves.all[18];
                playerStats.ATK[variables.characterNum] = 100;
                playerStats.DEF[variables.characterNum] = 125;
                playerStats.SPD[variables.characterNum] = 75;
                playerStats.HP[variables.characterNum] = 125;
            }
            if (classDD.Text == variables.classes[0] && elementDD.Text == variables.elements[4]) //04 - Melee Lightning
            {
                move4.Text = moves.all[19];
                playerStats.ATK[variables.characterNum] = 75;
                playerStats.DEF[variables.characterNum] = 125;
                playerStats.SPD[variables.characterNum] = 125;
                playerStats.HP[variables.characterNum] = 100;
            }
            if (classDD.Text == variables.classes[0] && elementDD.Text == variables.elements[5]) //05 - Melee Rock
            {
                move4.Text = moves.all[20];
                playerStats.ATK[variables.characterNum] = 100;
                playerStats.DEF[variables.characterNum] = 175;
                playerStats.SPD[variables.characterNum] = 50;
                playerStats.HP[variables.characterNum] = 100;
            }
            if (classDD.Text == variables.classes[0] && elementDD.Text == variables.elements[6]) //06 - Melee Magical
            {
                move4.Text = moves.all[21];
                playerStats.ATK[variables.characterNum] = 125;
                playerStats.DEF[variables.characterNum] = 125;
                playerStats.SPD[variables.characterNum] = 75;
                playerStats.HP[variables.characterNum] = 75;
            }
            if (classDD.Text == variables.classes[0] && elementDD.Text == variables.elements[7]) //07 - Melee Metal
            {
                move4.Text = moves.all[22];
                playerStats.ATK[variables.characterNum] = 100;
                playerStats.DEF[variables.characterNum] = 100;
                playerStats.SPD[variables.characterNum] = 75;
                playerStats.HP[variables.characterNum] = 125;
            }
            if (classDD.Text == variables.classes[0] && elementDD.Text == variables.elements[8]) //08 - Melee Air
            {
                move4.Text = moves.all[23];
                playerStats.ATK[variables.characterNum] = 100;
                playerStats.DEF[variables.characterNum] = 125;
                playerStats.SPD[variables.characterNum] = 100;
                playerStats.HP[variables.characterNum] = 100;
            }
            if (classDD.Text == variables.classes[0] && elementDD.Text == variables.elements[9]) //09 - Melee Toxic
            {
                move4.Text = moves.all[24];
                playerStats.ATK[variables.characterNum] = 125;
                playerStats.DEF[variables.characterNum] = 125;
                playerStats.SPD[variables.characterNum] = 75;
                playerStats.HP[variables.characterNum] = 100;
            }
            if (classDD.Text == variables.classes[1] && elementDD.Text == variables.elements[0]) //10 - Ranged Basic
            {
                move4.Text = moves.all[25];
                playerStats.ATK[variables.characterNum] = 75;
                playerStats.DEF[variables.characterNum] = 125;
                playerStats.SPD[variables.characterNum] = 125;
                playerStats.HP[variables.characterNum] = 100;
            }
            if (classDD.Text == variables.classes[1] && elementDD.Text == variables.elements[1]) //11 - Ranged Fire
            {
                move4.Text = moves.all[26];
                playerStats.ATK[variables.characterNum] = 100;
                playerStats.DEF[variables.characterNum] = 100;
                playerStats.SPD[variables.characterNum] = 125;
                playerStats.HP[variables.characterNum] = 100;
            }
            if (classDD.Text == variables.classes[1] && elementDD.Text == variables.elements[2]) //12 - Ranged Water
            {
                move4.Text = moves.all[27];
                playerStats.ATK[variables.characterNum] = 75;
                playerStats.DEF[variables.characterNum] = 100;
                playerStats.SPD[variables.characterNum] = 150;
                playerStats.HP[variables.characterNum] = 100;
            }
            if (classDD.Text == variables.classes[1] && elementDD.Text == variables.elements[3]) //13 - Ranged Life
            {
                move4.Text = moves.all[28];
                playerStats.ATK[variables.characterNum] = 75;
                playerStats.DEF[variables.characterNum] = 100;
                playerStats.SPD[variables.characterNum] = 125;
                playerStats.HP[variables.characterNum] = 125;
            }
            if (classDD.Text == variables.classes[1] && elementDD.Text == variables.elements[4]) //14 - Ranged Lightning
            {
                move4.Text = moves.all[29];
                playerStats.ATK[variables.characterNum] = 50;
                playerStats.DEF[variables.characterNum] = 100;
                playerStats.SPD[variables.characterNum] = 175;
                playerStats.HP[variables.characterNum] = 100;
            }
            if (classDD.Text == variables.classes[1] && elementDD.Text == variables.elements[5]) //15 - Ranged Rock
            {
                move4.Text = moves.all[30];
                playerStats.ATK[variables.characterNum] = 75;
                playerStats.DEF[variables.characterNum] = 150;
                playerStats.SPD[variables.characterNum] = 100;
                playerStats.HP[variables.characterNum] = 100;
            }
            if (classDD.Text == variables.classes[1] && elementDD.Text == variables.elements[6]) //16 - Ranged Magical
            {
                move4.Text = moves.all[31];
                playerStats.ATK[variables.characterNum] = 100;
                playerStats.DEF[variables.characterNum] = 100;
                playerStats.SPD[variables.characterNum] = 125;
                playerStats.HP[variables.characterNum] = 75;
            }
            if (classDD.Text == variables.classes[1] && elementDD.Text == variables.elements[7]) //17 - Ranged Metal
            {
                move4.Text = moves.all[32];
                playerStats.ATK[variables.characterNum] = 75;
                playerStats.DEF[variables.characterNum] = 75;
                playerStats.SPD[variables.characterNum] = 125;
                playerStats.HP[variables.characterNum] = 150;
            }
            if (classDD.Text == variables.classes[1] && elementDD.Text == variables.elements[8]) //18 - Ranged Air
            {
                move4.Text = moves.all[33];
                playerStats.ATK[variables.characterNum] = 75;
                playerStats.DEF[variables.characterNum] = 100;
                playerStats.SPD[variables.characterNum] = 150;
                playerStats.HP[variables.characterNum] = 100;
            }
            if (classDD.Text == variables.classes[1] && elementDD.Text == variables.elements[9]) //19 - Ranged Toxic
            {
                move4.Text = moves.all[34];
                playerStats.ATK[variables.characterNum] = 100;
                playerStats.DEF[variables.characterNum] = 100;
                playerStats.SPD[variables.characterNum] = 125;
                playerStats.HP[variables.characterNum] = 100;
            }
            if (classDD.Text == variables.classes[2] && elementDD.Text == variables.elements[0]) //20 - Mage Basic
            {
                move4.Text = moves.all[35];
                playerStats.ATK[variables.characterNum] = 125;
                playerStats.DEF[variables.characterNum] = 125;
                playerStats.SPD[variables.characterNum] = 100;
                playerStats.HP[variables.characterNum] = 75;
            }
            if (classDD.Text == variables.classes[2] && elementDD.Text == variables.elements[1]) //21 - Mage Fire
            {
                move4.Text = moves.all[36];
                playerStats.ATK[variables.characterNum] = 150;
                playerStats.DEF[variables.characterNum] = 100;
                playerStats.SPD[variables.characterNum] = 100;
                playerStats.HP[variables.characterNum] = 75;
            }
            if (classDD.Text == variables.classes[2] && elementDD.Text == variables.elements[2]) //22 - Mage Water
            {
                move4.Text = moves.all[37];
                playerStats.ATK[variables.characterNum] = 125;
                playerStats.DEF[variables.characterNum] = 100;
                playerStats.SPD[variables.characterNum] = 125;
                playerStats.HP[variables.characterNum] = 75;
            }
            if (classDD.Text == variables.classes[2] && elementDD.Text == variables.elements[3]) //23 - Mage Life
            {
                move4.Text = moves.all[38];
                playerStats.ATK[variables.characterNum] = 125;
                playerStats.DEF[variables.characterNum] = 100;
                playerStats.SPD[variables.characterNum] = 100;
                playerStats.HP[variables.characterNum] = 100;
            }
            if (classDD.Text == variables.classes[2] && elementDD.Text == variables.elements[4]) //24 - Mage Lightning
            {
                move4.Text = moves.all[39];
                playerStats.ATK[variables.characterNum] = 100;
                playerStats.DEF[variables.characterNum] = 100;
                playerStats.SPD[variables.characterNum] = 150;
                playerStats.HP[variables.characterNum] = 75;
            }
            if (classDD.Text == variables.classes[2] && elementDD.Text == variables.elements[5]) //25 - Mage Rock
            {
                move4.Text = moves.all[40];
                playerStats.ATK[variables.characterNum] = 125;
                playerStats.DEF[variables.characterNum] = 150;
                playerStats.SPD[variables.characterNum] = 75;
                playerStats.HP[variables.characterNum] = 75;
            }
            if (classDD.Text == variables.classes[2] && elementDD.Text == variables.elements[6]) //26 - Mage Magical
            {
                move4.Text = moves.all[41];
                playerStats.ATK[variables.characterNum] = 175;
                playerStats.DEF[variables.characterNum] = 100;
                playerStats.SPD[variables.characterNum] = 100;
                playerStats.HP[variables.characterNum] = 50;
            }
            if (classDD.Text == variables.classes[2] && elementDD.Text == variables.elements[7]) //27 - Mage Metal
            {
                move4.Text = moves.all[42];
                playerStats.ATK[variables.characterNum] = 125;
                playerStats.DEF[variables.characterNum] = 75;
                playerStats.SPD[variables.characterNum] = 100;
                playerStats.HP[variables.characterNum] = 125;
            }
            if (classDD.Text == variables.classes[2] && elementDD.Text == variables.elements[8]) //28 - Mage Air
            {
                move4.Text = moves.all[43];
                playerStats.ATK[variables.characterNum] = 125;
                playerStats.DEF[variables.characterNum] = 100;
                playerStats.SPD[variables.characterNum] = 125;
                playerStats.HP[variables.characterNum] = 75;
            }
            if (classDD.Text == variables.classes[2] && elementDD.Text == variables.elements[9]) //29 - Mage Toxic
            {
                move4.Text = moves.all[44];
                playerStats.ATK[variables.characterNum] = 150;
                playerStats.DEF[variables.characterNum] = 100;
                playerStats.SPD[variables.characterNum] = 100;
                playerStats.HP[variables.characterNum] = 75;
            }
            if (classDD.Text == variables.classes[3] && elementDD.Text == variables.elements[0]) //30 - Support Basic
            {
                move4.Text = moves.all[45];
                playerStats.ATK[variables.characterNum] = 100;
                playerStats.DEF[variables.characterNum] = 100;
                playerStats.SPD[variables.characterNum] = 100;
                playerStats.HP[variables.characterNum] = 125;
            }
            if (classDD.Text == variables.classes[3] && elementDD.Text == variables.elements[1]) //31 - Support Fire
            {
                move4.Text = moves.all[46];
                playerStats.ATK[variables.characterNum] = 125;
                playerStats.DEF[variables.characterNum] = 75;
                playerStats.SPD[variables.characterNum] = 100;
                playerStats.HP[variables.characterNum] = 125;
            }
            if (classDD.Text == variables.classes[3] && elementDD.Text == variables.elements[2]) //32 - Support Water
            {
                move4.Text = moves.all[47];
                playerStats.ATK[variables.characterNum] = 100;
                playerStats.DEF[variables.characterNum] = 75;
                playerStats.SPD[variables.characterNum] = 125;
                playerStats.HP[variables.characterNum] = 125;
            }
            if (classDD.Text == variables.classes[3] && elementDD.Text == variables.elements[3]) //33 - Support Life
            {
                move4.Text = moves.all[48];
                playerStats.ATK[variables.characterNum] = 100;
                playerStats.DEF[variables.characterNum] = 75;
                playerStats.SPD[variables.characterNum] = 100;
                playerStats.HP[variables.characterNum] = 150;
            }
            if (classDD.Text == variables.classes[3] && elementDD.Text == variables.elements[4]) //34 - Support Lightning
            {
                move4.Text = moves.all[49];
                playerStats.ATK[variables.characterNum] = 75;
                playerStats.DEF[variables.characterNum] = 75;
                playerStats.SPD[variables.characterNum] = 150;
                playerStats.HP[variables.characterNum] = 125;

            }
            if (classDD.Text == variables.classes[3] && elementDD.Text == variables.elements[5]) //35 - Support Rock
            {
                move4.Text = moves.all[50];
                playerStats.ATK[variables.characterNum] = 100;
                playerStats.DEF[variables.characterNum] = 125;
                playerStats.SPD[variables.characterNum] = 75;
                playerStats.HP[variables.characterNum] = 125;
            }
            if (classDD.Text == variables.classes[3] && elementDD.Text == variables.elements[6]) //36 - Support Magical
            {
                move4.Text = moves.all[51];
                playerStats.ATK[variables.characterNum] = 150;
                playerStats.DEF[variables.characterNum] = 75;
                playerStats.SPD[variables.characterNum] = 100;
                playerStats.HP[variables.characterNum] = 100;
            }
            if (classDD.Text == variables.classes[3] && elementDD.Text == variables.elements[7]) //37 - Support Metal
            {
                move4.Text = moves.all[52];
                playerStats.ATK[variables.characterNum] = 100;
                playerStats.DEF[variables.characterNum] = 50;
                playerStats.SPD[variables.characterNum] = 100;
                playerStats.HP[variables.characterNum] = 175;
            }
            if (classDD.Text == variables.classes[3] && elementDD.Text == variables.elements[8]) //38 - Support Air
            {
                move4.Text = moves.all[53];
                playerStats.ATK[variables.characterNum] = 100;
                playerStats.DEF[variables.characterNum] = 75;
                playerStats.SPD[variables.characterNum] = 125;
                playerStats.HP[variables.characterNum] = 125;
            }
            if (classDD.Text == variables.classes[3] && elementDD.Text == variables.elements[9]) //39 - Support Toxic
            {
                move4.Text = moves.all[54];
                playerStats.ATK[variables.characterNum] = 125;
                playerStats.DEF[variables.characterNum] = 75;
                playerStats.SPD[variables.characterNum] = 100;
                playerStats.HP[variables.characterNum] = 125;
            }
        }
        private void characterImageLoad()
        {
            CaCBody.Source = new BitmapImage(new Uri(@"/" + genderDD.Text + heightDD.Text + "_Body.png", UriKind.Relative)); //loading images into the game
            CaCFace.Source = new BitmapImage(new Uri(@"/" + faceDD.Text + genderDD + "_Face.png", UriKind.Relative));
            CaCHair.Source = new BitmapImage(new Uri(@"/" + hairDD.Text + "_Hair.png", UriKind.Relative));
            CaCHat.Source = new BitmapImage(new Uri(@"/" + hatDD.Text + "_Hat.png", UriKind.Relative));
            CaCClothes.Source = new BitmapImage(new Uri(@"/" + clothesDD.Text + genderDD + heightDD.Text + "_Clothes.png", UriKind.Relative));
        }
        private void saveMoves()
        {
            variables.playerMoves[variables.characterNum * 4] = move1.Text;
            variables.playerMoves[variables.characterNum * 4 + 1] = move2.Text;
            variables.playerMoves[variables.characterNum * 4 + 2] = move3.Text;
            variables.playerMoves[variables.characterNum * 4 + 3] = move4.Text;
        }
        private void setDDs()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            nameBox.Text = variables.playerName[variables.characterNum];
            classDD.Text = variables.playerClass[variables.characterNum];
            elementDD.Text = variables.playerElement[variables.characterNum];
            genderDD.Text = variables.playerGender[variables.characterNum];
            heightDD.Text = variables.playerHeight[variables.characterNum];
            faceDD.Text = variables.playerFace[variables.characterNum];
            hairDD.Text = variables.playerHair[variables.characterNum];
            hatDD.Text = variables.playerHat[variables.characterNum];
            clothesDD.Text = variables.playerClothes[variables.characterNum];
        }
    }
}