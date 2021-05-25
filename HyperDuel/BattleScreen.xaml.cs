using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Automation;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        decimal playerDamage = 0;
        decimal cpuDamage = 0;
        decimal playerHPBase = playerStats.HP[variables.characterNum];
        int playerATKBase = playerStats.ATK[variables.characterNum];
        int playerDEFBase = playerStats.DEF[variables.characterNum];
        int playerSPDBase = playerStats.SPD[variables.characterNum];
        decimal cpuHPbase = CPUStats.HP;
        int cpuATKbase = CPUStats.ATK;
        int cpuDEFbase = CPUStats.DEF;
        int cpuSPDbase = CPUStats.SPD;
        int moveTick;
        Random rnd = new Random();
        int MissChance = 0;
        int MoveMisses = 0;

        int CPU_ClassElement = 0;
        int moveNumber = 0;
        int cpuStatBoost = 0;
        int playerStatBoost = 0;
        int MoveChoice = 0;
        int playerStatusActive = 0;
        int cpuStatusActive = 0;
        string loser;
        string winner;
        bool playerCanAtk = true;
        bool cpuCanAtk = true;
        string i;
        public Window1()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            combatText.Text = "What will " + variables.playerName[variables.characterNum]  + " do?";
            if (variables.playerClass[variables.characterNum] == variables.classes[0])
            {
                move2.Content = moves.all[1];
            }
            if (variables.playerClass[variables.characterNum] == variables.classes[1])
            {
                move2.Content = moves.all[2];
            }
            if (variables.playerClass[variables.characterNum] == variables.classes[2])
            {
                move2.Content = moves.all[3];
            }
            if (variables.playerClass[variables.characterNum] == variables.classes[3])
            {
                move2.Content = moves.all[4];
            }
            if (variables.playerElement[variables.characterNum] == variables.elements[0])
            {
                move3.Content = moves.all[5];
                move3.Background = Brushes.Beige;
                move4.Background = Brushes.Beige;
            }
            if (variables.playerElement[variables.characterNum] == variables.elements[1])
            {
                move3.Content = moves.all[6];
                move3.Background = Brushes.Crimson;
                move4.Background = Brushes.Crimson;
            }
            if (variables.playerElement[variables.characterNum] == variables.elements[2])
            {
                move3.Content = moves.all[7];
                move3.Background = Brushes.SteelBlue;
                move4.Background = Brushes.SteelBlue;

            }
            if (variables.playerElement[variables.characterNum] == variables.elements[3])
            {
                move3.Content = moves.all[8];
                move3.Background = Brushes.Green;
                move4.Background = Brushes.Green;
            }
            if (variables.playerElement[variables.characterNum] == variables.elements[4])
            {
                move3.Content = moves.all[9];
                move3.Background = Brushes.Gold;
                move4.Background = Brushes.Gold;
            }
            if (variables.playerElement[variables.characterNum] == variables.elements[5])
            {
                move3.Content = moves.all[10];
                move3.Background = Brushes.RosyBrown;
                move4.Background = Brushes.RosyBrown;
            }
            if (variables.playerElement[variables.characterNum] == variables.elements[6])
            {
                move3.Content = moves.all[11];
                move3.Background = Brushes.MediumPurple;
                move4.Background = Brushes.MediumPurple;
            }
            if (variables.playerElement[variables.characterNum] == variables.elements[7])
            {
                move3.Content = moves.all[12];
                move3.Background = Brushes.SlateGray;
                move4.Background = Brushes.SlateGray;
            }
            if (variables.playerElement[variables.characterNum] == variables.elements[8])
            {
                move3.Content = moves.all[13];
                move3.Background = Brushes.DeepSkyBlue;
                move4.Background = Brushes.DeepSkyBlue;
            }
            if (variables.playerElement[variables.characterNum] == variables.elements[9])
            {
                move3.Content = moves.all[14];
                move3.Background = Brushes.Purple;
                move4.Background = Brushes.Purple;
            }
            if (variables.playerClass[variables.characterNum] == variables.classes[0] && variables.playerElement[variables.characterNum] == variables.elements[0])
            {
                move4.Content = moves.all[15];
            }
            if (variables.playerClass[variables.characterNum] == variables.classes[0] && variables.playerElement[variables.characterNum] == variables.elements[1])
            {
                move4.Content = moves.all[16];
            }
            if (variables.playerClass[variables.characterNum] == variables.classes[0] && variables.playerElement[variables.characterNum] == variables.elements[2])
            {
                move4.Content = moves.all[17];
            }
            if (variables.playerClass[variables.characterNum] == variables.classes[0] && variables.playerElement[variables.characterNum] == variables.elements[3])
            {
                move4.Content = moves.all[18];
            }
            if (variables.playerClass[variables.characterNum] == variables.classes[0] && variables.playerElement[variables.characterNum] == variables.elements[4])
            {
                move4.Content = moves.all[19];
            }
            if (variables.playerClass[variables.characterNum] == variables.classes[0] && variables.playerElement[variables.characterNum] == variables.elements[5])
            {
                move4.Content = moves.all[20];
            }
            if (variables.playerClass[variables.characterNum] == variables.classes[0] && variables.playerElement[variables.characterNum] == variables.elements[6])
            {
                move4.Content = moves.all[21];
            }
            if (variables.playerClass[variables.characterNum] == variables.classes[0] && variables.playerElement[variables.characterNum] == variables.elements[7])
            {
                move4.Content = moves.all[22];
            }
            if (variables.playerClass[variables.characterNum] == variables.classes[0] && variables.playerElement[variables.characterNum] == variables.elements[8])
            {
                move4.Content = moves.all[23];
            }
            if (variables.playerClass[variables.characterNum] == variables.classes[0] && variables.playerElement[variables.characterNum] == variables.elements[9])
            {
                move4.Content = moves.all[24];
            }
            if (variables.playerClass[variables.characterNum] == variables.classes[1] && variables.playerElement[variables.characterNum] == variables.elements[0])
            {
                move4.Content = moves.all[25];
            }
            if (variables.playerClass[variables.characterNum] == variables.classes[1] && variables.playerElement[variables.characterNum] == variables.elements[1])
            {
                move4.Content = moves.all[26];
            }
            if (variables.playerClass[variables.characterNum] == variables.classes[1] && variables.playerElement[variables.characterNum] == variables.elements[2])
            {
                move4.Content = moves.all[27];
            }
            if (variables.playerClass[variables.characterNum] == variables.classes[1] && variables.playerElement[variables.characterNum] == variables.elements[3])
            {
                move4.Content = moves.all[28];
            }
            if (variables.playerClass[variables.characterNum] == variables.classes[1] && variables.playerElement[variables.characterNum] == variables.elements[4])
            {
                move4.Content = moves.all[29];
            }
            if (variables.playerClass[variables.characterNum] == variables.classes[1] && variables.playerElement[variables.characterNum] == variables.elements[5])
            {
                move4.Content = moves.all[30];
            }
            if (variables.playerClass[variables.characterNum] == variables.classes[1] && variables.playerElement[variables.characterNum] == variables.elements[6])
            {
                move4.Content = moves.all[31];
            }
            if (variables.playerClass[variables.characterNum] == variables.classes[1] && variables.playerElement[variables.characterNum] == variables.elements[7])
            {
                move4.Content = moves.all[32];
            }
            if (variables.playerClass[variables.characterNum] == variables.classes[1] && variables.playerElement[variables.characterNum] == variables.elements[8])
            {
                move4.Content = moves.all[33];
            }
            if (variables.playerClass[variables.characterNum] == variables.classes[1] && variables.playerElement[variables.characterNum] == variables.elements[9])
            {
                move4.Content = moves.all[34];
            }
            if (variables.playerClass[variables.characterNum] == variables.classes[2] && variables.playerElement[variables.characterNum] == variables.elements[0])
            {
                move4.Content = moves.all[35];
            }
            if (variables.playerClass[variables.characterNum] == variables.classes[2] && variables.playerElement[variables.characterNum] == variables.elements[1])
            {
                move4.Content = moves.all[36];
            }
            if (variables.playerClass[variables.characterNum] == variables.classes[2] && variables.playerElement[variables.characterNum] == variables.elements[2])
            {
                move4.Content = moves.all[37];
            }
            if (variables.playerClass[variables.characterNum] == variables.classes[2] && variables.playerElement[variables.characterNum] == variables.elements[3])
            {
                move4.Content = moves.all[38];
            }
            if (variables.playerClass[variables.characterNum] == variables.classes[2] && variables.playerElement[variables.characterNum] == variables.elements[4])
            {
                move4.Content = moves.all[39];
            }
            if (variables.playerClass[variables.characterNum] == variables.classes[2] && variables.playerElement[variables.characterNum] == variables.elements[5])
            {
                move4.Content = moves.all[40];
            }
            if (variables.playerClass[variables.characterNum] == variables.classes[2] && variables.playerElement[variables.characterNum] == variables.elements[6])
            {
                move4.Content = moves.all[41];
            }
            if (variables.playerClass[variables.characterNum] == variables.classes[2] && variables.playerElement[variables.characterNum] == variables.elements[7])
            {
                move4.Content = moves.all[42];
            }
            if (variables.playerClass[variables.characterNum] == variables.classes[2] && variables.playerElement[variables.characterNum] == variables.elements[8])
            {
                move4.Content = moves.all[43];
            }
            if (variables.playerClass[variables.characterNum] == variables.classes[2] && variables.playerElement[variables.characterNum] == variables.elements[9])
            {
                move4.Content = moves.all[44];
            }
            if (variables.playerClass[variables.characterNum] == variables.classes[3] && variables.playerElement[variables.characterNum] == variables.elements[0])
            {
                move4.Content = moves.all[45];
            }
            if (variables.playerClass[variables.characterNum] == variables.classes[3] && variables.playerElement[variables.characterNum] == variables.elements[1])
            {
                move4.Content = moves.all[46];
            }
            if (variables.playerClass[variables.characterNum] == variables.classes[3] && variables.playerElement[variables.characterNum] == variables.elements[2])
            {
                move4.Content = moves.all[47];
            }
            if (variables.playerClass[variables.characterNum] == variables.classes[3] && variables.playerElement[variables.characterNum] == variables.elements[3])
            {
                move4.Content = moves.all[48];
            }
            if (variables.playerClass[variables.characterNum] == variables.classes[3] && variables.playerElement[variables.characterNum] == variables.elements[4])
            {
                move4.Content = moves.all[49];
            }
            if (variables.playerClass[variables.characterNum] == variables.classes[3] && variables.playerElement[variables.characterNum] == variables.elements[5])
            {
                move4.Content = moves.all[50];
            }
            if (variables.playerClass[variables.characterNum] == variables.classes[3] && variables.playerElement[variables.characterNum] == variables.elements[6])
            {
                move4.Content = moves.all[51];
            }
            if (variables.playerClass[variables.characterNum] == variables.classes[3] && variables.playerElement[variables.characterNum] == variables.elements[7])
            {
                move4.Content = moves.all[52];
            }
            if (variables.playerClass[variables.characterNum] == variables.classes[3] && variables.playerElement[variables.characterNum] == variables.elements[8])
            {
                move4.Content = moves.all[53];
            }
            if (variables.playerClass[variables.characterNum] == variables.classes[3] && variables.playerElement[variables.characterNum] == variables.elements[9])
            {
                move4.Content = moves.all[54];
            }
            CPU_ClassElement = rnd.Next(0, 4);
            if (CPU_ClassElement == 0)
            {
                variables.CPU_Class = variables.classes[0];
                variables.CPU_Moves[1] = moves.all[1];
            } else if (CPU_ClassElement == 1)
            {
                variables.CPU_Class = variables.classes[1];
                variables.CPU_Moves[1] = moves.all[2];
            } else if (CPU_ClassElement == 2)
            {
                variables.CPU_Class = variables.classes[2];
                variables.CPU_Moves[1] = moves.all[3];
            } else if (CPU_ClassElement == 3)
            {
                variables.CPU_Class = variables.classes[3];
                variables.CPU_Moves[1] = moves.all[4];
            }
            CPU_ClassElement = rnd.Next(0, 10);
            if (CPU_ClassElement == 0)
            {
                variables.CPU_Element = variables.elements[CPU_ClassElement];
                variables.CPU_Moves[2] = moves.all[CPU_ClassElement + 5];
                if (variables.CPU_Class == variables.classes[0])
                {
                    variables.CPU_Moves[3] = moves.all[CPU_ClassElement + 15];
                    CPUStats.ATK = 100;
                    CPUStats.DEF = 150;
                    CPUStats.SPD = 75;
                    CPUStats.HP = 100;
                }
                if (variables.CPU_Class == variables.classes[1])
                {
                    variables.CPU_Moves[3] = moves.all[CPU_ClassElement + 25];
                    CPUStats.ATK = 75;
                    CPUStats.DEF = 125;
                    CPUStats.SPD = 125;
                    CPUStats.HP = 100;
                }
                if (variables.CPU_Class == variables.classes[2])
                {
                    variables.CPU_Moves[3] = moves.all[CPU_ClassElement + 35];
                    CPUStats.ATK = 125;
                    CPUStats.DEF = 125;
                    CPUStats.SPD = 100;
                    CPUStats.HP = 75;
                }
                if (variables.CPU_Class == variables.classes[3])
                {
                    variables.CPU_Moves[3] = moves.all[CPU_ClassElement + 45];
                    CPUStats.ATK = 100;
                    CPUStats.DEF = 100;
                    CPUStats.SPD = 100;
                    CPUStats.HP = 125;
                }
            }
            else if (CPU_ClassElement == 1)
            {
                variables.CPU_Element = variables.elements[CPU_ClassElement];
                variables.CPU_Moves[2] = moves.all[CPU_ClassElement + 5];
                if (variables.CPU_Class == variables.classes[0])
                {
                    variables.CPU_Moves[3] = moves.all[CPU_ClassElement + 15];
                    CPUStats.ATK = 125;
                    CPUStats.DEF = 125;
                    CPUStats.SPD = 75;
                    CPUStats.HP = 100;
                }
                if (variables.CPU_Class == variables.classes[1])
                {
                    variables.CPU_Moves[3] = moves.all[CPU_ClassElement + 25];
                    CPUStats.ATK = 100;
                    CPUStats.DEF = 100;
                    CPUStats.SPD = 125;
                    CPUStats.HP = 100;
                }
                if (variables.CPU_Class == variables.classes[2])
                {
                    variables.CPU_Moves[3] = moves.all[CPU_ClassElement + 35];
                    CPUStats.ATK = 150;
                    CPUStats.DEF = 100;
                    CPUStats.SPD = 100;
                    CPUStats.HP = 75;
                }
                if (variables.CPU_Class == variables.classes[3])
                {
                    variables.CPU_Moves[3] = moves.all[CPU_ClassElement + 45];
                    CPUStats.ATK = 125;
                    CPUStats.DEF = 75;
                    CPUStats.SPD = 100;
                    CPUStats.HP = 125;
                }
            }
            else if (CPU_ClassElement == 2)
            {
                variables.CPU_Element = variables.elements[CPU_ClassElement];
                variables.CPU_Moves[2] = moves.all[CPU_ClassElement + 5];
                if (variables.CPU_Class == variables.classes[0])
                {
                    variables.CPU_Moves[3] = moves.all[CPU_ClassElement + 15];
                    CPUStats.ATK = 100;
                    CPUStats.DEF = 125;
                    CPUStats.SPD = 100;
                    CPUStats.HP = 100;
                }
                if (variables.CPU_Class == variables.classes[1])
                {
                    variables.CPU_Moves[3] = moves.all[CPU_ClassElement + 25];
                    CPUStats.ATK = 75;
                    CPUStats.DEF = 100;
                    CPUStats.SPD = 150;
                    CPUStats.HP = 100;
                }
                if (variables.CPU_Class == variables.classes[2])
                {
                    variables.CPU_Moves[3] = moves.all[CPU_ClassElement + 35];
                    CPUStats.ATK = 125;
                    CPUStats.DEF = 100;
                    CPUStats.SPD = 125;
                    CPUStats.HP = 75;
                }
                if (variables.CPU_Class == variables.classes[3])
                {
                    variables.CPU_Moves[3] = moves.all[CPU_ClassElement + 45];
                    CPUStats.ATK = 100;
                    CPUStats.DEF = 75;
                    CPUStats.SPD = 125;
                    CPUStats.HP = 125;
                }
            }
            else if (CPU_ClassElement == 3)
            {
                variables.CPU_Element = variables.elements[CPU_ClassElement];
                variables.CPU_Moves[2] = moves.all[CPU_ClassElement + 5];
                if (variables.CPU_Class == variables.classes[0])
                {
                    variables.CPU_Moves[3] = moves.all[CPU_ClassElement + 15];
                    CPUStats.ATK = 100;
                    CPUStats.DEF = 125;
                    CPUStats.SPD = 75;
                    CPUStats.HP = 125;
                }
                if (variables.CPU_Class == variables.classes[1])
                {
                    variables.CPU_Moves[3] = moves.all[CPU_ClassElement + 25];
                    CPUStats.ATK = 75;
                    CPUStats.DEF = 100;
                    CPUStats.SPD = 125;
                    CPUStats.HP = 125;
                }
                if (variables.CPU_Class == variables.classes[2])
                {
                    variables.CPU_Moves[3] = moves.all[CPU_ClassElement + 35];
                    CPUStats.ATK = 125;
                    CPUStats.DEF = 100;
                    CPUStats.SPD = 100;
                    CPUStats.HP = 100;
                }
                if (variables.CPU_Class == variables.classes[3])
                {
                    variables.CPU_Moves[3] = moves.all[CPU_ClassElement + 45];
                    CPUStats.ATK = 100;
                    CPUStats.DEF = 75;
                    CPUStats.SPD = 100;
                    CPUStats.HP = 150;
                }
            }
            else if (CPU_ClassElement == 4)
            {
                variables.CPU_Element = variables.elements[CPU_ClassElement];
                variables.CPU_Moves[2] = moves.all[CPU_ClassElement + 5];
                if (variables.CPU_Class == variables.classes[0])
                {
                    variables.CPU_Moves[3] = moves.all[CPU_ClassElement + 15];
                    CPUStats.ATK = 75;
                    CPUStats.DEF = 125;
                    CPUStats.SPD = 125;
                    CPUStats.HP = 100;
                }
                if (variables.CPU_Class == variables.classes[1])
                {
                    variables.CPU_Moves[3] = moves.all[CPU_ClassElement + 25];
                    CPUStats.ATK = 50;
                    CPUStats.DEF = 100;
                    CPUStats.SPD = 175;
                    CPUStats.HP = 100;
                }
                if (variables.CPU_Class == variables.classes[2])
                {
                    variables.CPU_Moves[3] = moves.all[CPU_ClassElement + 35];
                    CPUStats.ATK = 100;
                    CPUStats.DEF = 100;
                    CPUStats.SPD = 150;
                    CPUStats.HP = 75;
                }
                if (variables.CPU_Class == variables.classes[3])
                {
                    variables.CPU_Moves[3] = moves.all[CPU_ClassElement + 45];
                    CPUStats.ATK = 75;
                    CPUStats.DEF = 75;
                    CPUStats.SPD = 150;
                    CPUStats.HP = 125;
                }
            }
            else if (CPU_ClassElement == 5)
            {
                variables.CPU_Element = variables.elements[CPU_ClassElement];
                variables.CPU_Moves[2] = moves.all[CPU_ClassElement + 5];
                if (variables.CPU_Class == variables.classes[0])
                {
                    variables.CPU_Moves[3] = moves.all[CPU_ClassElement + 15];
                    CPUStats.ATK = 100;
                    CPUStats.DEF = 175;
                    CPUStats.SPD = 50;
                    CPUStats.HP = 100;
                }
                if (variables.CPU_Class == variables.classes[1])
                {
                    variables.CPU_Moves[3] = moves.all[CPU_ClassElement + 25];
                    CPUStats.ATK = 75;
                    CPUStats.DEF = 150;
                    CPUStats.SPD = 100;
                    CPUStats.HP = 100;
                }
                if (variables.CPU_Class == variables.classes[2])
                {
                    variables.CPU_Moves[3] = moves.all[CPU_ClassElement + 35];
                    CPUStats.ATK = 125;
                    CPUStats.DEF = 150;
                    CPUStats.SPD = 75;
                    CPUStats.HP = 75;
                }
                if (variables.CPU_Class == variables.classes[3])
                {
                    variables.CPU_Moves[3] = moves.all[CPU_ClassElement + 45];
                    CPUStats.ATK = 100;
                    CPUStats.DEF = 125;
                    CPUStats.SPD = 75;
                    CPUStats.HP = 125;
                }
            }
            else if (CPU_ClassElement == 6)
            {
                variables.CPU_Element = variables.elements[CPU_ClassElement];
                variables.CPU_Moves[2] = moves.all[CPU_ClassElement + 5];
                if (variables.CPU_Class == variables.classes[0])
                {
                    variables.CPU_Moves[3] = moves.all[CPU_ClassElement + 15];
                    CPUStats.ATK = 125;
                    CPUStats.DEF = 125;
                    CPUStats.SPD = 75;
                    CPUStats.HP = 75;
                }
                if (variables.CPU_Class == variables.classes[1])
                {
                    variables.CPU_Moves[3] = moves.all[CPU_ClassElement + 25];
                    CPUStats.ATK = 100;
                    CPUStats.DEF = 100;
                    CPUStats.SPD = 125;
                    CPUStats.HP = 75;
                }
                if (variables.CPU_Class == variables.classes[2])
                {
                    variables.CPU_Moves[3] = moves.all[CPU_ClassElement + 35];
                    CPUStats.ATK = 175;
                    CPUStats.DEF = 100;
                    CPUStats.SPD = 100;
                    CPUStats.HP = 50;
                }
                if (variables.CPU_Class == variables.classes[3])
                {
                    variables.CPU_Moves[3] = moves.all[CPU_ClassElement + 45];
                    CPUStats.ATK = 150;
                    CPUStats.DEF = 75;
                    CPUStats.SPD = 100;
                    CPUStats.HP = 100;
                }
            }
            else if (CPU_ClassElement == 7)
            {
                variables.CPU_Element = variables.elements[CPU_ClassElement];
                variables.CPU_Moves[2] = moves.all[CPU_ClassElement + 5];
                if (variables.CPU_Class == variables.classes[0])
                {
                    variables.CPU_Moves[3] = moves.all[CPU_ClassElement + 15];
                    CPUStats.ATK = 100;
                    CPUStats.DEF = 100;
                    CPUStats.SPD = 75;
                    CPUStats.HP = 125;
                }
                if (variables.CPU_Class == variables.classes[1])
                {
                    variables.CPU_Moves[3] = moves.all[CPU_ClassElement + 25];
                    CPUStats.ATK = 75;
                    CPUStats.DEF = 75;
                    CPUStats.SPD = 125;
                    CPUStats.HP = 150;
                }
                if (variables.CPU_Class == variables.classes[2])
                {
                    variables.CPU_Moves[3] = moves.all[CPU_ClassElement + 35];
                    CPUStats.ATK = 125;
                    CPUStats.DEF = 75;
                    CPUStats.SPD = 100;
                    CPUStats.HP = 125;
                }
                if (variables.CPU_Class == variables.classes[3])
                {
                    variables.CPU_Moves[3] = moves.all[CPU_ClassElement + 45];
                    CPUStats.ATK = 100;
                    CPUStats.DEF = 50;
                    CPUStats.SPD = 100;
                    CPUStats.HP = 175;
                }
            }
            else if (CPU_ClassElement == 8)
            {
                variables.CPU_Element = variables.elements[CPU_ClassElement];
                variables.CPU_Moves[2] = moves.all[CPU_ClassElement + 5];
                if (variables.CPU_Class == variables.classes[0])
                {
                    variables.CPU_Moves[3] = moves.all[CPU_ClassElement + 15];
                    CPUStats.ATK = 100;
                    CPUStats.DEF = 125;
                    CPUStats.SPD = 100;
                    CPUStats.HP = 100;
                }
                if (variables.CPU_Class == variables.classes[1])
                {
                    variables.CPU_Moves[3] = moves.all[CPU_ClassElement + 25];
                    CPUStats.ATK = 75;
                    CPUStats.DEF = 100;
                    CPUStats.SPD = 150;
                    CPUStats.HP = 100;
                }
                if (variables.CPU_Class == variables.classes[2])
                {
                    variables.CPU_Moves[3] = moves.all[CPU_ClassElement + 35];
                    CPUStats.ATK = 125;
                    CPUStats.DEF = 100;
                    CPUStats.SPD = 125;
                    CPUStats.HP = 75;
                }
                if (variables.CPU_Class == variables.classes[3])
                {
                    variables.CPU_Moves[3] = moves.all[CPU_ClassElement + 45];
                    CPUStats.ATK = 100;
                    CPUStats.DEF = 75;
                    CPUStats.SPD = 125;
                    CPUStats.HP = 125;
                }
            }
            else if (CPU_ClassElement == 9)
            {
                variables.CPU_Element = variables.elements[CPU_ClassElement];
                variables.CPU_Moves[2] = moves.all[CPU_ClassElement + 5];
                if (variables.CPU_Class == variables.classes[0])
                {
                    variables.CPU_Moves[3] = moves.all[CPU_ClassElement + 15];
                    CPUStats.ATK = 125;
                    CPUStats.DEF = 125;
                    CPUStats.SPD = 75;
                    CPUStats.HP = 100;
                }
                if (variables.CPU_Class == variables.classes[1])
                {
                    variables.CPU_Moves[3] = moves.all[CPU_ClassElement + 25];
                    CPUStats.ATK = 100;
                    CPUStats.DEF = 100;
                    CPUStats.SPD = 125;
                    CPUStats.HP = 100;
                }
                if (variables.CPU_Class == variables.classes[2])
                {
                    variables.CPU_Moves[3] = moves.all[CPU_ClassElement + 35];
                    CPUStats.ATK = 150;
                    CPUStats.DEF = 100;
                    CPUStats.SPD = 100;
                    CPUStats.HP = 75;
                }
                if (variables.CPU_Class == variables.classes[3])
                {
                    variables.CPU_Moves[3] = moves.all[CPU_ClassElement + 45];
                    CPUStats.ATK = 125;
                    CPUStats.DEF = 75;
                    CPUStats.SPD = 100;
                    CPUStats.HP = 125;
                }
            }
            cpuATKbase = CPUStats.ATK;
            cpuDEFbase = CPUStats.DEF;
            cpuSPDbase = CPUStats.SPD;
            cpuHPbase = CPUStats.HP;
            MessageBox.Show("Your opponent is a " + variables.CPU_Gender + " " + variables.CPU_Element + " " + variables.CPU_Class);
            playerHPbox.Text = variables.playerName[variables.characterNum]  + "'s stats -\nHP: " + playerHPBase + "\nATK: " + playerATKBase + "\nDEF: " + playerDEFBase + "\nSPD: " + playerSPDBase + "\nStatus: " + playerStats.STATUS[variables.characterNum];
            cpuHPbox.Text = "Opponent's stats -\nHP: " + cpuHPbase + "\nATK: " + cpuATKbase + "\nDEF: " + cpuDEFbase + "\nSPD: " + cpuSPDbase + "\nStatus: " + CPUStats.STATUS;
        }
        private void startAttack(object sender, RoutedEventArgs e)
        {
            playerDamage = 0;
            cpuDamage = 0;
            MoveMisses = 0;
            moveTick = 0;
            if (playerStatusActive > 0)
            {
                if (playerStats.STATUS[variables.characterNum] == moves.status[1])
                {
                    playerHPBase -= 5;
                    MessageBox.Show(variables.playerName[variables.characterNum]  + " took fire damage!");
                }
                else if (playerStats.STATUS[variables.characterNum] == moves.status[2])
                {
                    playerCanAtk = false;
                }
                else if (playerStats.STATUS[variables.characterNum] == moves.status[3])
                {
                    cpuCanAtk = false;
                }
                else if (playerStats.STATUS[variables.characterNum] == moves.status[4])
                {
                    playerHPBase -= 5;
                    MessageBox.Show(variables.playerName[variables.characterNum]  + " took poison damage!");
                }
                playerStatusActive -= 1;
            }
            else if (playerStatusActive == 0)
            {
                playerStats.STATUS[variables.characterNum] = moves.status[0];
            }
            if (cpuStatusActive > 0)
            {
                if (CPUStats.STATUS == moves.status[1])
                {
                    cpuHPbase -= 5;
                    MessageBox.Show("The opponent took fire damage!");
                }
                else if (CPUStats.STATUS == moves.status[2])
                {
                    cpuCanAtk = false;
                }
                else if (CPUStats.STATUS == moves.status[3])
                {
                    playerCanAtk = false;
                }
                else if (CPUStats.STATUS == moves.status[4])
                {
                    cpuHPbase -= 5;
                    MessageBox.Show("The opponent took poison damage!");
                }
                cpuStatusActive -= 1;
            }
            else if (cpuStatusActive == 0)
            {
                CPUStats.STATUS = moves.status[0];
            }
            if (cpuStatBoost > 0)
            {
                cpuStatBoost -= 1;
                if (cpuStatBoost == 0)
                {
                    cpuATKbase = CPUStats.ATK;
                    cpuDEFbase = CPUStats.DEF;
                    cpuSPDbase = CPUStats.SPD;
                    MessageBox.Show("The opponent's stats are back to normal");
                } else
                {
                    MessageBox.Show("The opponent's stats boosts are active!");
                }
            }
            if (playerStatBoost > 0)
            {
                playerStatBoost -= 1;
                if (playerStatBoost == 0)
                {
                    playerATKBase = playerStats.ATK[variables.characterNum];
                    playerDEFBase = playerStats.DEF[variables.characterNum];
                    playerSPDBase = playerStats.SPD[variables.characterNum];
                    MessageBox.Show("Your stats are back to normal!");
                } else
                {
                    MessageBox.Show("Your stats boosts are active!");
                }
            }
            //Finding out the moves
            Button btn = (Button)sender;
            i = "";
            i = btn.Name;
            if (i == "move1")
            {
                moveNumber = 1;
            }
            else if (i == "move2")
            {
                moveNumber = 2;
            }
            else if (i == "move3")
            {
                moveNumber = 3;
            }
            else if (i == "move4")
            {
                moveNumber = 4;
            }
            if (moveNumber == 2 && variables.playerMoves[variables.characterNum * 4 + 1] == moves.all[3])
            {
                playerSPDBase = 999;
            }
            if (moveNumber == 2 && variables.CPU_Moves[1] == moves.all[3])
            {
                cpuSPDbase = 999;
            }
            //Who goes first
            if (cpuSPDbase > playerSPDBase)
            {
                CPUMoves();
                playerMoves();
            }
            else
            {
                playerMoves();
                CPUMoves();
            }
            death_check();
        }
        private void CPUMoves()
        {
            if (cpuCanAtk == true)
            {
                MoveChoice = rnd.Next(1, 5);
                if (MoveChoice == 1)
                {
                    MessageBox.Show("The opponent uses " + variables.CPU_Moves[0]);
                    cpuDamage += cpuATKbase * 10 / playerDEFBase;
                    playerHPBase -= cpuDamage;
                    MessageBox.Show(variables.playerName[variables.characterNum]  + " took " + cpuDamage + " damage!");
                }
                if (MoveChoice == 2)
                {
                    MessageBox.Show("The opponent uses " + variables.CPU_Moves[1] + "!");
                    if (variables.CPU_Moves[1] == moves.all[1])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 10)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            cpuDamage += cpuATKbase * 30 / playerDEFBase;
                            playerHPBase -= cpuDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " took " + cpuDamage + " damage!");
                        }
                    }
                    if (variables.CPU_Moves[1] == moves.all[2])
                    {
                        moveTick = 4;
                        while (moveTick > 0)
                        {
                            MissChance = rnd.Next(1, 101);
                            if (MissChance <= 20)
                            {
                                MoveMisses += 1;
                                moveTick -= 1;
                            }
                            else
                            {
                                cpuDamage += cpuATKbase * 5 / playerDEFBase;
                                moveTick -= 1;
                            }
                        }
                        playerHPBase -= cpuDamage;
                        if (MoveMisses == 4)
                        {
                            MessageBox.Show("All the shots missed!");
                        }
                        else if (MoveMisses > 1)
                        {
                            MessageBox.Show(MoveMisses + " shots missed but " + variables.playerName[variables.characterNum]  + " still took " + cpuDamage + " damage!");
                        }
                        else if (MoveMisses == 1)
                        {
                            MessageBox.Show(MoveMisses + " shot missed but " + variables.playerName[variables.characterNum]  + " still took " + cpuDamage + " damage!");
                        }
                        else if (MoveMisses <= 0)
                        {
                            MessageBox.Show("All the shots hit! " + variables.playerName[variables.characterNum]  + " took " + cpuDamage + " damage!");
                        }
                    }
                    if (variables.CPU_Moves[1] == moves.all[3])
                    {
                        cpuStatBoost = 3;
                        cpuATKbase += 20;
                        cpuDEFbase += 30;
                        cpuSPDbase = CPUStats.SPD;
                        cpuSPDbase -= 20;

                        MessageBox.Show("For a drop in SPD, the opponent increased both their ATK and DEF");
                    }
                    if (variables.CPU_Moves[1] == moves.all[4])
                    {
                        cpuHPbase += 25;
                        MessageBox.Show("The opponent recoved 25 HP!");
                    }
                }
                if (MoveChoice == 3)
                {
                    MessageBox.Show("The opponent uses " + variables.CPU_Moves[2] + "!");
                    if (variables.CPU_Moves[2] == moves.all[5])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 20)
                        {
                            MessageBox.Show("The move missed");
                        }
                        else
                        {
                            cpuDamage += cpuATKbase * 30 / playerDEFBase;
                            playerHPBase -= cpuDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " took " + cpuDamage + " damage!");
                        }
                    }
                    if (variables.CPU_Moves[2] == moves.all[6])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 10)
                        {
                            MessageBox.Show("The move missed completely");
                        }
                        else if (MissChance <= 45)
                        {
                            playerStats.STATUS[variables.characterNum] = moves.status[1];
                            playerStatusActive = 3;
                            MessageBox.Show("The move missed but you are now " + playerStats.STATUS[variables.characterNum] + "!");
                        }
                        else
                        {
                            cpuDamage += cpuATKbase * 10 / playerDEFBase;
                            playerHPBase -= cpuDamage;
                            playerStats.STATUS[variables.characterNum] = moves.status[1];
                            playerStatusActive = 3;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " took " + cpuDamage + " damage and is now " + playerStats.STATUS[variables.characterNum] + "!");
                        }
                    }
                    if (variables.CPU_Moves[2] == moves.all[7])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 1)
                        {
                            MessageBox.Show("The move missed");
                        }
                        else
                        {
                            cpuDamage += cpuATKbase * 10 / playerDEFBase;
                            playerHPBase -= cpuDamage;
                            if (playerStats.STATUS[variables.characterNum] == moves.status[1])
                            {
                                playerStatusActive = 0;
                                playerStats.STATUS[variables.characterNum] = moves.status[0];
                                MessageBox.Show(variables.playerName[variables.characterNum]  + " took " + cpuDamage + " and their status is now " + playerStats.STATUS[variables.characterNum] + "!");
                            }
                            else
                            {
                                MessageBox.Show(variables.playerName[variables.characterNum]  + " took " + cpuDamage + " damage!");
                            }
                        }
                    }
                    if (variables.CPU_Moves[2] == moves.all[8])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 10)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            cpuDamage += cpuATKbase * 20 / playerDEFBase;
                            playerHPBase -= cpuDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " took " + cpuDamage + " damage!");
                        }
                    }
                    if (variables.CPU_Moves[2] == moves.all[9])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 5)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else if (MissChance <= 15)
                        {
                            cpuDamage += cpuATKbase * 15 / playerDEFBase;
                            playerHPBase -= cpuDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " took " + cpuDamage + " damage!");
                            if (MissChance <= 20)
                            {
                                playerStats.STATUS[variables.characterNum] = moves.status[2];
                                playerStatusActive = 3;
                                MessageBox.Show(variables.playerName[variables.characterNum]  + " took " + cpuDamage + " damage and is now " + playerStats.STATUS[variables.characterNum] + "!");
                            }
                        }
                    }
                    if (variables.CPU_Moves[2] == moves.all[10])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 55)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            cpuDamage += cpuATKbase * 50 / playerDEFBase;
                            playerHPBase -= cpuDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " took " + cpuDamage + " damage!");
                        }
                    }
                    if (variables.CPU_Moves[2] == moves.all[11])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 10)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            cpuDamage += cpuATKbase * 25 / playerDEFBase;
                            playerHPBase -= cpuDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " took " + cpuDamage + " damage!");
                        }
                    }
                    if (variables.CPU_Moves[2] == moves.all[12])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 5)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            cpuDamage += cpuATKbase * 20 / playerDEFBase;
                            playerHPBase -= cpuDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " took " + cpuDamage + " damage!");
                        }
                    }
                    if (variables.CPU_Moves[2] == moves.all[13])
                    {
                        CPUStats.STATUS = moves.status[3];
                        cpuStatusActive = 3;
                        MessageBox.Show("The opponent is now " + CPUStats.STATUS + "!");
                    }
                    if (variables.CPU_Moves[2] == moves.all[14])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 5)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            cpuDamage += cpuATKbase * 10 / playerDEFBase;
                            playerHPBase -= cpuDamage;
                            playerStats.STATUS[variables.characterNum] = moves.status[4];
                            playerStatusActive = 3;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " took " + cpuDamage + " damage, and is now " + playerStats.STATUS[variables.characterNum] + "!");
                        }
                    }
                }
                if (MoveChoice == 4)
                {
                    MessageBox.Show("The opponent uses " + variables.CPU_Moves[3] + "!");
                    if (variables.CPU_Moves[3] == moves.all[15])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 5)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            cpuDamage += cpuATKbase * 50 / playerDEFBase;
                            playerHPBase -= cpuDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " took " + cpuDamage + " damage!");
                        }
                    }
                    if (variables.CPU_Moves[3] == moves.all[16])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 10)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            cpuDamage += cpuATKbase * 20 / playerDEFBase;
                            playerHPBase -= cpuDamage;
                            playerStats.STATUS[variables.characterNum] = moves.status[1];
                            playerStatusActive = 3;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " took " + cpuDamage + " damage, and is now " + playerStats.STATUS[variables.characterNum] + "!");
                        }
                    }
                    if (variables.CPU_Moves[3] == moves.all[17])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 5)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            cpuDamage += cpuATKbase * 20 / playerDEFBase;
                            playerHPBase -= cpuDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " took " + cpuDamage + " damage!");
                        }
                    }
                    if (variables.CPU_Moves[3] == moves.all[18])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 10)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            cpuDamage += cpuATKbase * 30 / playerDEFBase;
                            playerHPBase -= cpuDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " took " + cpuDamage + " damage!");
                        }
                    }
                    if (variables.CPU_Moves[3] == moves.all[19])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 10)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            cpuDamage += cpuATKbase * 30 / playerDEFBase;
                            playerHPBase -= cpuDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " took " + cpuDamage + " damage!");
                            if (MissChance <= 15)
                            {
                                playerStats.STATUS[variables.characterNum] = moves.status[2];
                                playerStatusActive = 3;
                                MessageBox.Show(variables.playerName[variables.characterNum]  + " took " + cpuDamage + " damage, and is now " + playerStats.STATUS[variables.characterNum] + "!");
                            }
                        }
                    }
                    if (variables.CPU_Moves[3] == moves.all[20])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 40)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            cpuDamage += cpuATKbase * 60 / playerDEFBase;
                            playerHPBase -= cpuDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " took " + cpuDamage + " damage!");
                        }
                    }
                    if (variables.CPU_Moves[3] == moves.all[21])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 10)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            cpuDamage += cpuATKbase * 30 / playerDEFBase;
                            playerHPBase -= cpuDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " took " + cpuDamage + " damage!");
                        }
                    }
                    if (variables.CPU_Moves[3] == moves.all[22])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 15)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            cpuDamage += cpuATKbase * 40 / playerDEFBase;
                            playerHPBase -= cpuDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " took " + cpuDamage + " damage!");
                        }
                    }
                    if (variables.CPU_Moves[3] == moves.all[23])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 5)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            cpuDamage += cpuATKbase * 20 / playerDEFBase;
                            playerHPBase -= cpuDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " took " + cpuDamage + " damage!");
                        }
                    }
                    if (variables.CPU_Moves[3] == moves.all[24])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 10)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            cpuDamage += cpuATKbase * 30 / playerDEFBase;
                            playerHPBase -= cpuDamage;
                            playerStats.STATUS[variables.characterNum] = moves.status[4];
                            playerStatusActive = 3;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " took " + cpuDamage + " damage, and is now " + playerStats.STATUS[variables.characterNum] + "!");
                        }
                    }
                    if (variables.CPU_Moves[3] == moves.all[25])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 5)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            cpuDamage += cpuATKbase * 20 / playerDEFBase;
                            playerHPBase -= cpuDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " took " + cpuDamage + " damage!");
                        }
                    }
                    if (variables.CPU_Moves[3] == moves.all[26])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 5)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            cpuDamage += cpuATKbase * 10 / playerDEFBase;
                            playerHPBase -= cpuDamage;
                            playerStats.STATUS[variables.characterNum] = moves.status[1];
                            playerStatusActive = 3;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " took " + cpuDamage + " damage, and is now " + playerStats.STATUS[variables.characterNum] + "!");
                        }
                    }
                    if (variables.CPU_Moves[3] == moves.all[27])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 30)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            cpuDamage += cpuATKbase * 50 / playerDEFBase;
                            playerHPBase -= cpuDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " took " + cpuDamage + " damage!");
                        }
                    }
                    if (variables.CPU_Moves[3] == moves.all[28])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 20)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            cpuDamage += cpuATKbase * 40 / playerDEFBase;
                            playerHPBase -= cpuDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " took " + cpuDamage + " damage!");
                        }
                    }
                    if (variables.CPU_Moves[3] == moves.all[29])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 5)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            cpuDamage += cpuATKbase * 10 / playerDEFBase;
                            playerHPBase -= cpuDamage;
                            playerStats.STATUS[variables.characterNum] = moves.status[2];
                            playerStatusActive = 3;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " took " + cpuDamage + " danage, and is now " + playerStats.STATUS[variables.characterNum] + "!");
                        }
                    }
                    if (variables.CPU_Moves[3] == moves.all[30])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 40)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            cpuDamage += cpuATKbase * 80 / playerDEFBase;
                            playerHPBase -= cpuDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " took " + cpuDamage + " damage!");
                        }
                    }
                    if (variables.CPU_Moves[3] == moves.all[31])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 0)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            cpuDamage += cpuATKbase * 30 / playerDEFBase;
                            playerHPBase -= cpuDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " took " + cpuDamage + " damage!");
                        }
                    }
                    if (variables.CPU_Moves[3] == moves.all[32])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 5)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            cpuDamage += cpuATKbase * 30 / playerDEFBase;
                            playerHPBase -= cpuDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " took " + cpuDamage + " damage!");
                        }
                    }
                    if (variables.CPU_Moves[3] == moves.all[33])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 5)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            cpuDamage += cpuATKbase * 20 / playerDEFBase;
                            playerHPBase -= cpuDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " took " + cpuDamage + " damage!");
                        }
                    }
                    if (variables.CPU_Moves[3] == moves.all[34])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 10)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            cpuDamage += cpuATKbase * 20 / playerDEFBase;
                            playerHPBase -= cpuDamage;
                            playerStats.STATUS[variables.characterNum] = moves.status[4];
                            playerStatusActive = 3;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " took " + cpuDamage + " damage, and is now " + playerStats.STATUS[variables.characterNum] + "!");
                        }
                    }
                    if (variables.CPU_Moves[3] == moves.all[35])
                    {
                        CPUStats.STATUS = moves.status[0];
                        MessageBox.Show("The opponent is now " + CPUStats.STATUS + "!");
                    }
                    if (variables.CPU_Moves[3] == moves.all[36])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 50)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            cpuDamage += cpuATKbase * 100 / playerDEFBase;
                            playerHPBase -= cpuDamage;
                            playerStats.STATUS[variables.characterNum] = moves.status[1];
                            playerStatusActive = 3;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " took " + cpuDamage + " damage, and is now " + playerStats.STATUS[variables.characterNum] + "!");
                        }
                    }
                    if (variables.CPU_Moves[3] == moves.all[37])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 20)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            cpuDamage += cpuATKbase * 60 / playerDEFBase;
                            playerHPBase -= cpuDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " took " + cpuDamage + " damage!");
                        }
                    }
                    if (variables.CPU_Moves[3] == moves.all[38])
                    {
                        CPUStats.STATUS = moves.status[0];
                        cpuHPbase += 30;
                        MessageBox.Show("The opponent recoved 30 HP and is now " + CPUStats.STATUS + "!");
                    }
                    if (variables.CPU_Moves[3] == moves.all[39])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 60)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            cpuDamage += cpuATKbase * 120 / playerDEFBase;
                            playerHPBase -= cpuDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " took " + cpuDamage + " damage!");
                        }
                    }
                    if (variables.CPU_Moves[3] == moves.all[40])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 0)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            cpuDamage += cpuATKbase * 100 / playerDEFBase;
                            playerHPBase -= cpuDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " took " + cpuDamage + " damage!");
                        }
                    }
                    if (variables.CPU_Moves[3] == moves.all[41])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 5)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            cpuDamage += cpuATKbase * 10 / playerDEFBase;
                            playerHPBase -= cpuDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " took " + cpuDamage + " damage!");
                        }
                    }
                    if (variables.CPU_Moves[3] == moves.all[42])
                    {
                        cpuStatBoost = 3;
                        cpuDEFbase += 30;
                        MessageBox.Show("The opponent gained 30 DEF");
                    }
                    if (variables.CPU_Moves[3] == moves.all[43])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 5)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            cpuDamage += cpuATKbase * 100 / playerDEFBase;
                            playerHPBase -= cpuDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " took " + cpuDamage + " damage!");
                        }
                    }
                    if (variables.CPU_Moves[3] == moves.all[44])
                    {
                        cpuDamage += cpuATKbase * 50 / playerDEFBase;
                        playerHPBase -= cpuDamage;
                        playerStats.STATUS[variables.characterNum] = moves.status[4];
                        playerStatusActive = 3;
                        MessageBox.Show(variables.playerName[variables.characterNum]  + " took " + cpuDamage + " damage, and is now " + playerStats.STATUS[variables.characterNum] + "!");
                    }
                    if (variables.CPU_Moves[3] == moves.all[45])
                    {
                        cpuHPbase = CPUStats.HP;
                        MessageBox.Show("The opponent recoved all their HP");
                    }
                    if (variables.CPU_Moves[3] == moves.all[46])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 5)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            cpuDamage += cpuATKbase * 50 / playerDEFBase;
                            playerHPBase -= cpuDamage;
                            playerStats.STATUS[variables.characterNum] = moves.status[1];
                            playerStatusActive = 3;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " took " + cpuDamage + " damage, and is now " + playerStats.STATUS[variables.characterNum] + "!");
                        }
                    }
                    if (variables.CPU_Moves[3] == moves.all[47])
                    {
                        CPUStats.STATUS = moves.status[0];
                        playerStats.STATUS[variables.characterNum] = moves.status[0];
                        MessageBox.Show("Everyone is now " + moves.status[0] + ".");
                    }
                    if (variables.CPU_Moves[3] == moves.all[48])
                    {
                        cpuHPbase += 100;
                        MessageBox.Show("The opponent recoved 100 HP!");
                    }
                    if (variables.CPU_Moves[3] == moves.all[49])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 5)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            cpuDamage += cpuATKbase * 10 / playerDEFBase;
                            playerHPBase -= cpuDamage;
                            playerStats.STATUS[variables.characterNum] = moves.status[2];
                            playerStatusActive = 3;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " took " + cpuDamage + " damage, and is now " + playerStats.STATUS[variables.characterNum] + "!");
                        }
                    }
                    if (variables.CPU_Moves[3] == moves.all[50])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 5)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            cpuDamage += cpuATKbase * 20 / playerDEFBase;
                            playerHPBase -= cpuDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " took " + cpuDamage + " damage!");
                        }
                    }
                    if (variables.CPU_Moves[3] == moves.all[51])
                    {
                        CPUStats.STATUS = moves.status[0];
                        playerStats.STATUS[variables.characterNum] = moves.status[0];
                        MessageBox.Show("Everyone is now " + moves.status[0] + "!");
                    }
                    if (variables.CPU_Moves[3] == moves.all[52])
                    {
                        cpuStatBoost = 3;
                        cpuDEFbase += 75;
                        MessageBox.Show("The opponent buffed their DEF!");
                    }
                    if (variables.CPU_Moves[3] == moves.all[53])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 5)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            cpuDamage += cpuATKbase * 40 / playerDEFBase;
                            playerHPBase -= cpuDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " took " + cpuDamage + " damage!");
                        }
                    }
                    if (variables.CPU_Moves[3] == moves.all[54])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 0)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            cpuDamage += cpuATKbase * 10 / playerDEFBase;
                            playerHPBase -= cpuDamage;
                            playerStats.STATUS[variables.characterNum] = moves.status[4];
                            playerStatusActive = 3;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " took " + cpuDamage + " damage, and is now " + playerStats.STATUS[variables.characterNum] + "!");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("The opponent was unable to attack!");
            }
        }
        private void playerMoves()
        {
            if (playerCanAtk == true)
            {
                if (moveNumber == 1)
                {
                    MessageBox.Show(variables.playerName[variables.characterNum]  + " uses " + variables.playerMoves[variables.characterNum * 4] + "!");
                    playerDamage += playerATKBase * 10 / cpuDEFbase;
                    cpuHPbase -= playerDamage;
                    MessageBox.Show(variables.playerName[variables.characterNum]  + " dealt " + playerDamage + " damage!");
                }
                if (moveNumber == 2)
                {
                    MessageBox.Show(variables.playerName[variables.characterNum]  + " uses " + variables.playerMoves[variables.characterNum * 4 + 1] + "!");
                    if (variables.playerMoves[variables.characterNum * 4 + 1] == moves.all[1])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 10)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            playerDamage += playerATKBase * 30 / cpuDEFbase;
                            cpuHPbase -= playerDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " dealt " + playerDamage + " damage!");
                        }
                    }
                    if (variables.playerMoves[variables.characterNum * 4 + 1] == moves.all[2])
                    {
                        moveTick = 4;
                        while (moveTick > 0)
                        {
                            MissChance = rnd.Next(1, 101);
                            if (MissChance <= 20)
                            {
                                MoveMisses += 1;
                                moveTick -= 1;
                            }
                            else
                            {
                                playerDamage += playerATKBase * 5 / cpuDEFbase;
                                moveTick -= 1;
                            }
                        }
                        cpuHPbase -= playerDamage;
                        if (MoveMisses == 4)
                        {
                            MessageBox.Show("All the shots missed!");
                        }
                        else if (MoveMisses > 1)
                        {
                            MessageBox.Show(MoveMisses + " shots missed but " + variables.playerName[variables.characterNum]  + " still dealt " + playerDamage + " damage!");
                        }
                        else if (MoveMisses == 1)
                        {
                            MessageBox.Show(MoveMisses + " shot missed but " + variables.playerName[variables.characterNum]  + " still dealt " + playerDamage + " damage!");
                        }
                        else if (MoveMisses <= 0)
                        {
                            MessageBox.Show("All the shots hit! " + variables.playerName[variables.characterNum]  + " dealt " + playerDamage + " damage!");
                        }
                    }
                    if (variables.playerMoves[variables.characterNum * 4 + 1] == moves.all[3])
                    {
                        playerStatBoost = 3;
                        playerATKBase += 20;
                        playerDEFBase += 30;
                        playerSPDBase = CPUStats.SPD;
                        playerSPDBase -= 20;
                        MessageBox.Show("For a drop in SPD, " + variables.playerName[variables.characterNum]  + " increased both their ATK and DEF");
                    }
                    if (variables.playerMoves[variables.characterNum * 4 + 1] == moves.all[4])
                    {
                        cpuHPbase += 25;
                        MessageBox.Show(variables.playerName[variables.characterNum]  + " recoved 25 HP!");
                    }
                }
                if (moveNumber == 3)
                {
                    MessageBox.Show(variables.playerName[variables.characterNum]  + " uses " + variables.playerMoves[variables.characterNum * 4 + 2] + "!");
                    if (variables.playerMoves[variables.characterNum * 4 + 2] == moves.all[5])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 20)
                        {
                            MessageBox.Show("The move missed");
                        }
                        else
                        {
                            playerDamage += playerATKBase * 30 / cpuDEFbase;
                            cpuHPbase -= playerDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " dealt " + playerDamage + " damage!");
                        }
                    }
                    if (variables.playerMoves[variables.characterNum * 4 + 2] == moves.all[6])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 10)
                        {
                            MessageBox.Show("The move missed completely");
                        }
                        else if (MissChance <= 45)
                        {
                            CPUStats.STATUS = moves.status[1];
                            cpuStatusActive = 3;
                            MessageBox.Show("The move missed but the opponent is now " + CPUStats.STATUS + "!");
                        }
                        else
                        {
                            playerDamage += playerATKBase * 10 / cpuDEFbase;
                            cpuHPbase -= playerDamage;
                            CPUStats.STATUS = moves.status[1];
                            cpuStatusActive = 3;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " dealt " + playerDamage + " damage and the opponent is now " + CPUStats.STATUS + "!");
                        }
                    }
                    if (variables.playerMoves[variables.characterNum * 4 + 2] == moves.all[7])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 1)
                        {
                            MessageBox.Show("The move missed");
                        }
                        else
                        {
                            playerDamage += playerATKBase * 10 / cpuDEFbase;
                            cpuHPbase -= playerDamage;
                            if (CPUStats.STATUS == moves.status[1])
                            {
                                cpuStatusActive = 0;
                                CPUStats.STATUS = moves.status[0];
                                MessageBox.Show(variables.playerName[variables.characterNum]  + " dealt " + playerDamage + " damage and the opponent's status is now " + CPUStats.STATUS + "!");
                            }
                            else
                            {
                                MessageBox.Show(variables.playerName[variables.characterNum]  + " dealt " + playerDamage + " damage!");
                            }
                        }
                    }
                    if (variables.playerMoves[variables.characterNum * 4 + 2] == moves.all[8])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 10)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            playerDamage += playerATKBase * 20 / cpuDEFbase;
                            cpuHPbase -= playerDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " dealt " + playerDamage + " damage!");
                        }
                    }
                    if (variables.playerMoves[variables.characterNum * 4 + 2] == moves.all[9])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 5)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else if (MissChance <= 15)
                        {
                            playerDamage += playerATKBase * 15 / cpuDEFbase;
                            cpuHPbase -= playerDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " dealt " + playerDamage + " damage!");
                            if (MissChance <= 20)
                            {
                                CPUStats.STATUS = moves.status[2];
                                cpuStatusActive = 3;
                                MessageBox.Show(variables.playerName[variables.characterNum]  + " dealt " + playerDamage + " damage and is now " + CPUStats.STATUS + "!");
                            }
                        }
                    }
                    if (variables.playerMoves[variables.characterNum * 4 + 2] == moves.all[10])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 55)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            playerDamage += playerATKBase * 50 / cpuDEFbase;
                            cpuHPbase -= playerDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " dealt " + playerDamage + " damage!");
                        }
                    }
                    if (variables.playerMoves[variables.characterNum * 4 + 2] == moves.all[11])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 10)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            playerDamage += playerATKBase * 25 / cpuDEFbase;
                            cpuHPbase -= playerDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " dealt " + playerDamage + " damage!");
                        }
                    }
                    if (variables.playerMoves[variables.characterNum * 4 + 2] == moves.all[12])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 5)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            playerDamage += playerATKBase * 20 / cpuDEFbase;
                            cpuHPbase -= playerDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " dealt " + playerDamage + " damage!");
                        }
                    }
                    if (variables.playerMoves[variables.characterNum * 4 + 2] == moves.all[13])
                    {
                        playerStats.STATUS[variables.characterNum] = moves.status[3];
                        playerStatusActive = 3;
                        MessageBox.Show(variables.playerName[variables.characterNum]  + " is now " + playerStats.STATUS[variables.characterNum] + "!");
                    }
                    if (variables.playerMoves[variables.characterNum * 4 + 2] == moves.all[14])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 5)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            playerDamage += playerATKBase * 10 / cpuDEFbase;
                            cpuHPbase -= playerDamage;
                            CPUStats.STATUS = moves.status[4];
                            cpuStatusActive = 3;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " dealt " + playerDamage + " damage, and the opponent is now " + CPUStats.STATUS + "!");
                        }
                    }
                }
                if (moveNumber == 4)
                {
                    MessageBox.Show(variables.playerName[variables.characterNum]  + " uses " + variables.playerMoves[3] + "!");
                    if (variables.playerMoves[3] == moves.all[15])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 5)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            playerDamage += playerATKBase * 50 / cpuDEFbase;
                            cpuHPbase -= playerDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " dealt " + playerDamage + "  damage!");
                        }
                    }
                    if (variables.playerMoves[3] == moves.all[16])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 10)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            playerDamage += playerATKBase * 20 / cpuDEFbase;
                            cpuHPbase -= playerDamage;
                            CPUStats.STATUS = moves.status[1];
                            cpuStatusActive = 3;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " dealt " + playerDamage + " damage, and the opponent is now " + CPUStats.STATUS + "!");
                        }
                    }
                    if (variables.playerMoves[3] == moves.all[17])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 5)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            playerDamage += playerATKBase * 20 / cpuDEFbase;
                            cpuHPbase -= playerDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " dealt " + playerDamage + " damage!");
                        }
                    }
                    if (variables.playerMoves[3] == moves.all[18])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 10)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            playerDamage += playerATKBase * 30 / cpuDEFbase;
                            cpuHPbase -= playerDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " dealt " + playerDamage + " damage!");
                        }
                    }
                    if (variables.playerMoves[3] == moves.all[19])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 10)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            playerDamage += playerATKBase * 30 / cpuDEFbase;
                            cpuHPbase -= playerDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " dealt " + playerDamage + " damage!");
                            if (MissChance <= 15)
                            {
                                CPUStats.STATUS = moves.status[2];
                                cpuStatusActive = 3;
                                MessageBox.Show(variables.playerName[variables.characterNum]  + " dealt " + playerDamage + "  damge, and the opponent is now " + CPUStats.STATUS + "!");
                            }
                        }
                    }
                    if (variables.playerMoves[3] == moves.all[20])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 40)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            playerDamage += playerATKBase * 60 / cpuDEFbase;
                            cpuHPbase -= playerDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " dealt " + playerDamage + " damage!");
                        }
                    }
                    if (variables.playerMoves[3] == moves.all[21])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 10)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            playerDamage += playerATKBase * 30 / cpuDEFbase;
                            cpuHPbase -= playerDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " dealt " + playerDamage + " damage!");
                        }
                    }
                    if (variables.playerMoves[3] == moves.all[22])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 15)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            playerDamage += playerATKBase * 40 / cpuDEFbase;
                            cpuHPbase -= playerDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " dealt " + playerDamage + " damage!");
                        }
                    }
                    if (variables.playerMoves[3] == moves.all[23])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 5)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            playerDamage += playerATKBase * 20 / cpuDEFbase;
                            cpuHPbase -= playerDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " dealt " + playerDamage + " damage!");
                        }
                    }
                    if (variables.playerMoves[3] == moves.all[24])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 10)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            playerDamage += playerATKBase * 30 / cpuDEFbase;
                            cpuHPbase -= playerDamage;
                            CPUStats.STATUS = moves.status[4];
                            cpuStatusActive = 3;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " dealt " + playerDamage + " damage, and the opponent is now " + CPUStats.STATUS + "!");
                        }
                    }
                    if (variables.playerMoves[3] == moves.all[25])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 5)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            playerDamage += playerATKBase * 20 / cpuDEFbase;
                            cpuHPbase -= playerDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " dealt " + playerDamage + " damage!");
                        }
                    }
                    if (variables.playerMoves[3] == moves.all[26])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 5)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            playerDamage += playerATKBase * 10 / cpuDEFbase;
                            cpuHPbase -= playerDamage;
                            playerStats.STATUS[variables.characterNum] = moves.status[1];
                            playerStatusActive = 3;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " dealt " + playerDamage + ", and is now " + playerStats.STATUS[variables.characterNum]+ "!");
                        }
                    }
                    if (variables.playerMoves[3] == moves.all[27])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 30)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            playerDamage += playerATKBase * 50 / cpuDEFbase;
                            cpuHPbase -= playerDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " dealt " + playerDamage + " damage!");
                        }
                    }
                    if (variables.playerMoves[3] == moves.all[28])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 20)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            playerDamage += playerATKBase * 40 / cpuDEFbase;
                            cpuHPbase -= playerDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " dealt " + playerDamage + " damage!");
                        }
                    }
                    if (variables.playerMoves[3] == moves.all[29])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 5)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            playerDamage += playerATKBase * 10 / cpuDEFbase;
                            cpuHPbase -= playerDamage;
                            CPUStats.STATUS = moves.status[2];
                            cpuStatusActive = 3;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " dealt " + playerDamage + " damage, and the opponent is now " + CPUStats.STATUS + "!");
                        }
                    }
                    if (variables.playerMoves[3] == moves.all[30])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 40)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            playerDamage += playerATKBase * 80 / cpuDEFbase;
                            cpuHPbase -= playerDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " dealt " + playerDamage + " damage!");
                        }
                    }
                    if (variables.playerMoves[3] == moves.all[31])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 0)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            playerDamage += playerATKBase * 30 / cpuDEFbase;
                            cpuHPbase -= playerDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " dealt " + playerDamage + " damage!");
                        }
                    }
                    if (variables.playerMoves[3] == moves.all[32])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 5)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            playerDamage += playerATKBase * 30 / cpuDEFbase;
                            cpuHPbase -= playerDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " dealt " + playerDamage + " damage!");
                        }
                    }
                    if (variables.playerMoves[3] == moves.all[33])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 5)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            playerDamage += playerATKBase * 20 / cpuDEFbase;
                            cpuHPbase -= playerDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " dealt " + playerDamage + " damage!");
                        }
                    }
                    if (variables.playerMoves[3] == moves.all[34])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 10)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            playerDamage += playerATKBase * 20 / cpuDEFbase;
                            cpuHPbase -= playerDamage;
                            CPUStats.STATUS = moves.status[4];
                            cpuStatusActive = 3;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " dealt " + playerDamage + " damage, and the opponent is now " + CPUStats.STATUS + "!");
                        }
                    }
                    if (variables.playerMoves[3] == moves.all[35])
                    {
                        playerStats.STATUS[variables.characterNum] = moves.status[0];
                        MessageBox.Show(variables.playerName[variables.characterNum]  + " is now " +playerStats.STATUS[variables.characterNum]+ "!");
                    }
                    if (variables.playerMoves[3] == moves.all[36])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 50)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            playerDamage += playerATKBase * 100 / cpuDEFbase;
                            cpuHPbase -= playerDamage;
                            CPUStats.STATUS = moves.status[1];
                            cpuStatusActive = 3;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " dealt " + playerDamage + " damage, and the opponent is now " + CPUStats.STATUS + "!");
                        }
                    }
                    if (variables.playerMoves[3] == moves.all[37])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 20)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            playerDamage += playerATKBase * 60 / cpuDEFbase;
                            cpuHPbase -= playerDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " dealt " + playerDamage + " damage!");
                        }
                    }
                    if (variables.playerMoves[3] == moves.all[38])
                    {
                       playerStats.STATUS[variables.characterNum]= moves.status[0];
                        playerHPBase += 30;
                        MessageBox.Show(variables.playerName[variables.characterNum]  + " recoved 30 HP and is now " +playerStats.STATUS[variables.characterNum]+ "!");
                    }
                    if (variables.playerMoves[3] == moves.all[39])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 60)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            playerDamage += playerATKBase * 120 / cpuDEFbase;
                            cpuHPbase -= playerDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " dealt " + playerDamage + " damage!");
                        }
                    }
                    if (variables.playerMoves[3] == moves.all[40])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 0)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            playerDamage += playerATKBase * 100 / cpuDEFbase;
                            cpuHPbase -= playerDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " dealt " + playerDamage + " damage!");
                        }
                    }
                    if (variables.playerMoves[3] == moves.all[41])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 5)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            playerDamage += playerATKBase * 10 / cpuDEFbase;
                            cpuHPbase -= playerDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " dealt " + playerDamage + " damage!");
                        }
                    }
                    if (variables.playerMoves[3] == moves.all[42])
                    {
                        playerStatBoost = 3;
                        playerDEFBase += 30;
                        MessageBox.Show(variables.playerName[variables.characterNum]  + " gained 30 DEF");
                    }
                    if (variables.playerMoves[3] == moves.all[43])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 5)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            playerDamage += playerATKBase * 100 / cpuDEFbase;
                            cpuHPbase -= playerDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " dealt " + playerDamage + " damage!");
                        }
                    }
                    if (variables.playerMoves[3] == moves.all[44])
                    {
                        playerDamage += playerATKBase * 50 / cpuDEFbase;
                        cpuHPbase -= playerDamage;
                        CPUStats.STATUS = moves.status[4];
                        cpuStatusActive = 3;
                        MessageBox.Show(variables.playerName[variables.characterNum]  + " dealt " + playerDamage + " damage, and the opponent is now " +playerStats.STATUS[variables.characterNum]+ "!");
                    }
                    if (variables.playerMoves[3] == moves.all[45])
                    {
                        playerHPBase = playerStats.HP[variables.characterNum];
                        MessageBox.Show(variables.playerName[variables.characterNum]  + " recoved all their HP");
                    }
                    if (variables.playerMoves[3] == moves.all[46])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 5)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            playerDamage += playerATKBase * 50 / cpuDEFbase;
                            cpuHPbase -= playerDamage;
                            CPUStats.STATUS = moves.status[1];
                            cpuStatusActive = 3;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " dealt " + playerDamage + " damage, and the opponent is now " + CPUStats.STATUS + "!");
                        }
                    }
                    if (variables.playerMoves[3] == moves.all[47])
                    {
                        CPUStats.STATUS = moves.status[0];
                       playerStats.STATUS[variables.characterNum]= moves.status[0];
                        MessageBox.Show("Everyone is now " + moves.status[0] + ".");
                    }
                    if (variables.playerMoves[3] == moves.all[48])
                    {
                        playerHPBase += 100;
                        MessageBox.Show(variables.playerName[variables.characterNum]  + " recoved 100 HP!");
                    }
                    if (variables.playerMoves[3] == moves.all[49])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 5)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            playerDamage += playerATKBase * 10 / cpuDEFbase;
                            cpuHPbase -= playerDamage;
                            CPUStats.STATUS = moves.status[2];
                            cpuStatusActive = 3;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " dealt " + playerDamage + " damage, and the opponent is now " + CPUStats.STATUS + "!");
                        }
                    }
                    if (variables.playerMoves[3] == moves.all[50])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 5)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            playerDamage += playerATKBase * 20 / cpuDEFbase;
                            cpuHPbase -= playerDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " dealt " + playerDamage + " damage!");
                        }
                    }
                    if (variables.playerMoves[3] == moves.all[51])
                    {
                        CPUStats.STATUS = moves.status[0];
                       playerStats.STATUS[variables.characterNum]= moves.status[0];
                        MessageBox.Show("Everyone is now " + moves.status[0] + "!");
                    }
                    if (variables.playerMoves[3] == moves.all[52])
                    {
                        playerStatBoost = 3;
                        playerDEFBase += 75;
                        MessageBox.Show(variables.playerName[variables.characterNum]  + " buffed their DEF!");
                    }
                    if (variables.playerMoves[3] == moves.all[53])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 5)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            playerDamage += playerATKBase * 40 / cpuDEFbase;
                            cpuHPbase -= playerDamage;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " dealt " + playerDamage + " damage!");
                        }
                    }
                    if (variables.playerMoves[3] == moves.all[54])
                    {
                        MissChance = rnd.Next(1, 101);
                        if (MissChance <= 0)
                        {
                            MessageBox.Show("The move missed!");
                        }
                        else
                        {
                            playerDamage += playerATKBase * 10 / cpuDEFbase;
                            cpuHPbase -= playerDamage;
                            CPUStats.STATUS = moves.status[4];
                            cpuStatusActive = 3;
                            MessageBox.Show(variables.playerName[variables.characterNum]  + " dealt " + playerDamage + " damage, and the opponent is now " + CPUStats.STATUS + "!");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show(variables.playerName[variables.characterNum]  + " was unable to attack!");
            }
        }
        private void death_check()
        {
            playerHPbox.Text = variables.playerName[variables.characterNum]  + "'s stats -\nHP: " + playerHPBase + "\nATK: " + playerATKBase + "\nDEF: " + playerDEFBase + "\nSPD: " + playerSPDBase + "\nStatus: " + playerStats.STATUS;
            cpuHPbox.Text = "Opponent's stats -\nHP: " + cpuHPbase + "\nATK: " + cpuATKbase + "\nDEF: " + cpuDEFbase + "\nSPD: " + cpuSPDbase + "\nStatus: " + CPUStats.STATUS;
            if (playerHPBase <= 0)
            {
                loser = variables.playerName[variables.characterNum] ;
                winner = "CPU";
                gameEnd();
            }
            if (cpuHPbase <= 0)
            {
                winner = variables.playerName[variables.characterNum] ;
                loser = "CPU";
                gameEnd();
            }
        }
        private void gameEnd()
        {
            playerStats.STATUS[variables.characterNum]= moves.status[0];
            CPUStats.STATUS = moves.status[0];
            MessageBox.Show("The winner is " + winner + "!\n" + loser + " has lost.");
            MessageBox.Show("The game will now return to the main menu.");
            MessageBox.Show(playerStats.HP[variables.characterNum] + "\n" + playerStats.ATK[variables.characterNum] + "\n" + playerStats.DEF[variables.characterNum] + "\n" + playerStats.SPD[variables.characterNum] + "\n" + playerStats.STATUS[variables.characterNum]+ "\n" + CPUStats.STATUS);
            new MainWindow().Show();
            Close();
        }
    }
}