using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.RightsManagement;
using System.Threading.Tasks;
using System.Windows;

namespace HyperDuel
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
    }
    public class variables
    {
        public static string[] playerClass = new string[255];
        public static string[] playerElement = new string[255];
        public static string[] playerGender = new string[255];
        public static string[] playerHeight = new string[255];
        public static string[] playerFace = new string[255];
        public static string[] playerHair = new string[255];
        public static string[] playerHat = new string[255];
        public static string[] playerClothes = new string[255];
        public static string[] playerMoves = new string[255];
        public static string[] playerName = new string[255];
        public static int characterNum = 0;
        public static string[] classes = { "Melee", "Ranged", "Mage", "Support" }; //all possible classes
        public static string[] elements = { "Basic", "Fire", "Water", "Life", "Lighting", "Rock", "Magical", "Metal", "Air", "Toxic" }; //all possible elements
        public static string CPU_Class = "";
        public static string CPU_Element = "";
        public static string CPU_Gender = "";
        public static string CPU_Height = "";
        public static string CPU_Face = "";
        public static string CPU_Hair = "";
        public static string CPU_Hat = "";
        public static string CPU_Clothes = "";
        public static string[] CPU_Moves = { "Hit", "", "", "" };
        public static bool characterMade = false;
    }
    public class playerStats
    {
        public static decimal[] HP = new decimal[255];
        public static int[] ATK = new int[255];
        public static int[] DEF = new int[255];
        public static int[] SPD = new int[255];
        public static string[] STATUS = new string[255];
    }
    public class CPUStats
    {
        public static decimal HP;
        public static int ATK;
        public static int DEF;
        public static int SPD;
        public static string STATUS = moves.status[0];
    }
    public class moves
    {
        public static string[] all = { //0
                                         "Hit",
                                       //1             2             3              4
                                         "Heavy Bash", "Rapid Fire", "Mana Return", "Basic Heal",
                                       //5              6           7         8            9        10            11             12       13     14
                                         "Heavy Punch", "Fireball", "Splash", "Vine Whip", "Shock", "Rock Throw", "Magic Blast", "Slash", "Fly", "Sludge Ball",
                                       //15      16             17      18              19               20           21                    22         23             24
                                         "Rush", "Flame Sword", "Surf", "Rapid Strike", "Electric Rush", "Rock Bash", "Blades of Infinity", "X-Slash", "Aerial Dash", "Toxic Swipe",
                                       //25                 26              27             28            29                  30             31                 32                33                34
                                         "Pirercing Arrow", "Rain of Fire", "Water Blast", "Razor Leaf", "Lighting Barrage", "Boulder Lob", "Heaven's Arrows", "Bullet Barrage", "Rain of Arrows", "Toxic Spit",
                                       //35         36           37           38          39               40            41       42              43         44
                                         "Nullify", "EXplosion", "Whirlpool", "Blessing", "Lighting Bolt", "Earthquake", "Expel", "Iron Control", "Tornado", "Toxic Clone",
                                       //45         46          47            48              49       50           51             52           53           54
                                         "Bandage", "Firewall", "Rain Dance", "Tree of Life", "Storm", "Sandstorm", "Magic Realm", "Armour Up", "Windstorm", "Poison Gas"}; //all possible moves
        public static string[] status = { "fine", "on fire", "shocked", "flying", "poisoned"};
    }
}
