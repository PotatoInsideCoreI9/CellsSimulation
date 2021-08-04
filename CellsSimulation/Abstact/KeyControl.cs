using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellsSimulation.Abstact
{
    abstract class KeyControl
    {
        public virtual bool React(ref int x, ref int y, PressEvent press) => false;
        public virtual bool StartEvent(PressEvent key, ref int x, ref int y) => false;
        
    }
}
