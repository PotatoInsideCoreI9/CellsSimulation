using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CellsSimulation
{
    class View
    {
        DialogResult result;
        FileManeger fileManeger;
        CellField cellField;
        public View() {
             fileManeger = new FileManeger();
             cellField = new CellField(20);
        }
        public void Start()
        {
            result = MessageBox.Show("Welcome to cell simulator \n you can load your own file or draw cells in sandbox mode \n Yes - Enter sandbox mode \n No - Load txt file with coordinats", "Cell Simulator", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            switch (result)
            {
                case DialogResult.Yes:
                    {
                        MessageBox.Show("press W,A,S,D to move in matrix,press Q to save cell", "Sandbox mode", MessageBoxButtons.OK);
                        cellField.SandBox();
                        result = MessageBox.Show("Save to file?", "Sandbox mode", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                            fileManeger.Save(cellField);
                        cellField.Simulate();
                        break;
                    }
                case DialogResult.No:
                    {
                        cellField.AddCells(fileManeger.Read());
                        break;
                    }
            }
            cellField.Simulate();
        }
    }
}
