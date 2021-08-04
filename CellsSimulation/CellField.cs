using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CellsSimulation
{
  class CellField : IEnumerable
    {
        internal Cell[][] field ;
        int size;
        public int Borned { set; get; }
        List<Cell> NextGen;
        public CellField() { }
        public CellField (int s1)
        {
            
            size = s1;
            field = new Cell[s1][];
            NextGen = new List<Cell>();
            for (int i = 0; i < field.Length; i++)
                field[i] = new Cell[size];
            for (int i = 0; i < field.Length; i++)
                for (int j = 0; j < field[i].Length; j++)
                    field[i][j] = new Cell() { Position = new int[2] { i, j }, Live = false, Born = false };
        }

        public void AddCells(List<Cell> cells)
        {
            foreach (var cell in cells)
                field[cell.Position[0]][cell.Position[1]] = cell;
        }

        void Clear()
        {
            field = new Cell[size][];
            for (int i = 0; i < field.Length; i++)
                field[i] = new Cell[size];
            for (int i = 0; i < field.Length; i++)
                for (int j = 0; j < field[i].Length; j++)
                    field[i][j] = new Cell() { Live = false, Position = new int[2] { i, j } };
        }

        void CountNeiboors(Cell cell)
        {
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    int col = (cell.Position[0] + i + field[cell.Position[0]].Length) % field[cell.Position[0]].Length;
                    int row = (cell.Position[1] + j + field[cell.Position[1]].Length) % field[cell.Position[1]].Length;
                    bool isSelfCheck = col == cell.Position[0] && row == cell.Position[1];
                    if (field[col][row] != null)
                    {
                        var hasLife = field[col][row].Live;
                        if (hasLife && !isSelfCheck)
                            cell.Neighbors++;
                    }
                }
            }
        }

        void NextGeneration()
        {

            for (int i = 0; i < field.Length; i++)
                for (int j = 0; j < field[i].Length; j++)
                {
                    if (field[i][j] != null)
                    {
                        CountNeiboors(field[i][j]);

                        switch (field[i][j].Neighbors)
                        {
                            case 2:
                                {
                                    if (field[i][j].Live)
                                    {
                                        NextGen.Add(field[i][j]);
                                        field[i][j].Neighbors = 0;
                                    }
                                    break;
                                }
                            case 3:
                                {
                                    if (!field[i][j].Live)
                                    {
                                        field[i][j].Born = true;

                                        NextGen.Add(field[i][j]);
                                        field[i][j].Neighbors = 0;
                                        break;
                                    }
                                    NextGen.Add(field[i][j]);
                                    field[i][j].Neighbors = 0;
                                    break;
                                }
                            default:
                                {   
                                 field[i][j].Neighbors = 0;
                                 break;
                                }

                        }

                      
                    }
                }

            Clear();

            foreach (var cell in NextGen)
            {
                if (cell.Born)
                {
                    Borned++;
                    cell.Live = true;
                }
                field[cell.Position[0]][cell.Position[1]] = cell;
            }
            if (NextGen.Count == 1)
            {
                Console.WriteLine("еволюция окончена");
              
                return;
            }
            NextGen.Clear();
        }

        public void SandBox()
        {
            int x = 0, y = 0;
            PressEvent key = new PressEvent();
            key.KeyInfo = Console.ReadKey();
           
            KeyPress action = new KeyPress(key.KeyInfo);
            while (true)
            {

                key.KeyInfo = Console.ReadKey();
                key.Cells = this;
                if (action.StartEvent(key,ref x,ref y))
                {
                    Console.WriteLine("exit");
                    return;
                }
            }
        }

        public void Simulate()
        {
            Console.WriteLine("press any key to exit");
            Console.ReadKey();
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    Console.WriteLine("break;");
                    break;
                }
                Console.Clear();
                show();
                NextGeneration();
                Thread.Sleep(1000);
                Console.Clear();
                show();
                GC.Collect();
            }
        }

        public void show()
        {
            for (int i = 0; i < field.Length; i++)
            {
                foreach (var cells in field[i])
                    Console.Write(cells.ToString());
                Console.WriteLine();
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => (IEnumerator)GetEnumerator();
        public CellEnumerator GetEnumerator() => new CellEnumerator(field);
        public  Tuple<int, int> IndexOf(Cell cell)
        {
            for (int i = 0; i < field.Length; i++)
                for (int j = 0; j < field[i].Length; j++)
                    if (field[i][j] == cell)
                        return new Tuple<int, int>(i, j);
            return new Tuple<int, int>(0, 0);
         
        }
    }
    
}
