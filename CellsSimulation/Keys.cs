using CellsSimulation.Abstact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellsSimulation
{

        public delegate bool KeyDelegate(ref int x,ref int y, PressEvent press);
        public class PressEvent: EventArgs
        {
            public ConsoleKeyInfo KeyInfo { get; set; }
            internal CellField Cells { get; set; }
        }
        class KeyPress : KeyControl
        {
            public event KeyDelegate keyPressEvent;
            public override bool React(ref int x, ref int y, PressEvent press)
            {
            
            ConsoleKeyInfo save;
                switch (press.KeyInfo.Key)
                {
                    case ConsoleKey.W:
                        {
                           
                            x--;
                        if (x <0)
                        {
                            Console.WriteLine($"range y {x}");
                            y = 0;
                            break;
                        }
                        press.Cells.show();
                        Console.Clear();
                      
                        press.Cells.field[x][y].Live = true;
                        press.Cells.show();
                        save = Console.ReadKey();
                        if (save.Key == ConsoleKey.Q)
                        {
                            Console.WriteLine("Save!");
                            press.Cells.field[x][y].Saved = true;
                            Console.ReadKey();
                        }
                        else
                        {
                            if (press.Cells.field[x][y].Saved != null && press.Cells.field[x][y].Saved)
                                break;
                            else
                            {
                                press.Cells.field[x][y].Live = false;
                                press.Cells.field[x][y].Saved = false;
                            }
                        }
                        break;
                        }
                    case ConsoleKey.D:
                        {
                            y++;
                            if (y >=press.Cells.field[x].Length)
                            {
                                Console.WriteLine($"range y {y}");
                                y = 0;
                                break;
                            }
                            press.Cells.show();
                            Console.Clear();
                       
                        press.Cells.field[x][y].Live = true;
                        press.Cells.show();
                        save = Console.ReadKey();
                        if (save.Key == ConsoleKey.Q)
                        {
                            Console.WriteLine("Save!");
                            press.Cells.field[x][y].Saved = true;
                            Console.ReadKey();
                        }
                        else
                        {
                            if (press.Cells.field[x][y].Saved != null && press.Cells.field[x][y].Saved)
                                break;
                            else
                            {
                                press.Cells.field[x][y].Live = false;
                                press.Cells.field[x][y].Saved = false;
                            }
                        }
                        break;
                        }
                    case ConsoleKey.A:
                        {
                            y--;
                           
                        if (y<0)
                        {
                            Console.WriteLine($"range y {y}");
                            y = 0;
                            break;
                        }
                        press.Cells.show();
                        Console.Clear();
                        
                        press.Cells.field[x][y].Live = true;
                        press.Cells.show();
                        save = Console.ReadKey();
                        if (save.Key == ConsoleKey.Q)
                        {
                            Console.WriteLine("Save!");
                            press.Cells.field[x][y].Saved = true;
                            Console.ReadKey();
                        }
                        else
                        {
                            if (press.Cells.field[x][y].Saved != null && press.Cells.field[x][y].Saved)
                                break;
                            else
                            {
                                press.Cells.field[x][y].Live = false;
                                press.Cells.field[x][y].Saved = false;
                            }
                        }
                        break;
                        }
                case ConsoleKey.S:
                        {
                            x++;
                           
                        if (x > press.Cells.field.Length)
                        {
                            Console.WriteLine($"range y {x}");
                            y = 0;
                            break;
                        }
                        press.Cells.show();
                        Console.Clear();
                        press.Cells.field[x][y].Live = true;
                        press.Cells.show();
                        save = Console.ReadKey();
                        if (save.Key == ConsoleKey.Q)
                        {
                            Console.WriteLine("Save!");
                            press.Cells.field[x][y].Saved = true;
                            Console.ReadKey();
                        }
                        else
                        {
                            if (press.Cells.field[x][y].Saved != null && press.Cells.field[x][y].Saved)
                                break;
                            else
                            {
                                press.Cells.field[x][y].Live = false;
                                press.Cells.field[x][y].Saved = false;
                            }
                        }
                        break;
                        }
                    case ConsoleKey.Escape:
                        {
                            return true;
                            break;
                        }
            }
                return false;
            }

        internal KeyPress(ConsoleKeyInfo key)
        {
            keyPressEvent += React;

        }

        public override bool StartEvent(PressEvent key, ref int x, ref int y)
        {
            if (keyPressEvent != null)
                if (keyPressEvent(  ref x, ref y,key))
                    return true;
            return false;
        }
    }

   
}
