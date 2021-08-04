using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CellsSimulation
{
    // ссилка на правила гри https://life.written.ru/game_of_life_review_by_gardner
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            View view = new View();
            view.Start();
            Console.ReadKey();
        }
    }
}
