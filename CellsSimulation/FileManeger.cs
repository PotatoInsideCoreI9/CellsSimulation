using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CellsSimulation
{
    class FileManeger
    {
        
        public string Path { get; set; }
        OpenFileDialog dl;
        FileStream file;
        public void Save(CellField field)
        {
           // save = new SaveFileDialog();
            dl = new OpenFileDialog();
            dl.Filter = "text documents (.txt)|*txt";
            dl.ShowDialog();
            Path = dl.FileName;
            byte[] buff;
            string position;
            try
            {
                Clear();
                file = new FileStream(dl.FileName, FileMode.Append, FileAccess.Write);


                StreamWriter sw = new StreamWriter(file, Encoding.Unicode);
                foreach (Cell cell in field)
                {
                    if (cell.Live)
                    {
                        position = $"{cell.Position[0]},{cell.Position[1]}\n";
                        buff = System.Text.Encoding.Unicode.GetBytes(position);
                        file.Write(buff, 0, buff.Length);
                    }
                }
                file.Close();
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
           
        }
        
        public List<Cell> Read()
        {
            List<Cell> cells= new List<Cell>();
            dl = new OpenFileDialog();
            dl.Filter = "text documents (.txt)|*txt";
            dl.ShowDialog();
            string[] numbers=null;
            Console.WriteLine(dl.FileName);
            Path = dl.FileName;
            
            try
            {
                file = new FileStream(Path, FileMode.Open, FileAccess.Read);
                byte[] buf = new byte[(int)file.Length];
                using (StreamReader sr = new StreamReader(Path, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        numbers = line.Split(new char[] { ',' });
                        cells.Add(new Cell() { Live = true, Position = new int[] { Int32.Parse(numbers[0]), Int32.Parse(numbers[1]) } });
                    }
                }
                file.Close();
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            return cells;
        }

        private void Clear()
        {
            if(Path!=null)
            {
                File.WriteAllText(Path, String.Empty);
            }
        }
    }
}
