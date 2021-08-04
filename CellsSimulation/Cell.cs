using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellsSimulation.Interfaces;

namespace CellsSimulation
{
    class Cell :ICell
    {
        public bool Live { get; set; }
        public int Neighbors { get; set; }
        public bool Born { get; set; }
        public int[] Position { get; set; }
        public ICell[] cells { get; set; }
        public bool Saved { get; set; }
        public Cell() { Neighbors = 0; }
        public string ToString()
        {
            if (Live)
                return "■";
            else
                return " ";
        }
     
    }
}
