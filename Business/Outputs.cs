using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Outputs
    {
        public string filePath { get; set; }

        public Outputs(string filePath)
        {
            this.filePath = filePath;
        }

        public bool writeToFile(List<string> outLines)
        {               
            FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fileStream);

            foreach (string line in outLines)
            {
                writer.WriteLine(line);
            }
            writer.Close();
            fileStream.Close();

            return true;
        }
    }
}
