using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineButtonGame
{
    internal class GameManager
    {
        public static Player CurrentPlayer { get; set; }
        public static int GridSize => 2 + CurrentPlayer.Level; // Увеличивается с каждым уровнем
        public static Random Rand = new Random();

        public static (int row, int col) GenerateBombPosition(int size)
        {
            return (Rand.Next(size), Rand.Next(size));
        }
    }
}
