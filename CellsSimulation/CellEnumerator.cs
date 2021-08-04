using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellsSimulation
{
    class CellEnumerator : IEnumerator
    {
        Cell[][] cells;
        int position = 0,position1=0;
        public CellEnumerator(Cell[][] cells) { this.cells = cells; }
        object IEnumerator.Current { get { return Current; } }
        public Cell Current
        {
            get {
              //  Console.WriteLine($"position {position},{position1}");
                    if(position1<cells[position].Length)
                        return cells[position][position1];
                return cells[0][0];
                }
        }

        public bool MoveNext()
        {
            position1++;
            if (position1 == cells[position].Length)
            {
                position1 = 0;
                position++;
                //Console.WriteLine("new arr");
            }
            
            bool indexator = position < cells.Length;
            return indexator;
            return true;
        }

        public void Reset() { Console.WriteLine("reset"); ; position = -1; position1 = -1; }
    }
}
