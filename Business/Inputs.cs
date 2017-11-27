using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Inputs
    {
        public string filePath { get; set; }

        public Inputs(string filePath)
        {
            this.filePath = filePath;
        }

        public List<string> readFile()
        {
            List<string> commands = new List<string>();

            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(fileStream);

            string line = reader.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                commands.Add(line);
                line = reader.ReadLine();
            }
            reader.Close();
            fileStream.Close();

            return commands;
        }
    }
}
