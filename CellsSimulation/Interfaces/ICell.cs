using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellsSimulation.Interfaces
{
    interface ICell
    {
        int[] Position { get; set; }
        bool Live { get; set; }
        int Neighbors { get; set; }
        bool Born { get; set; }
    }   
}
