using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    /// <summary>
    /// Text dosyasını işleyecek olan sınıf
    /// </summary>
    public  class StringHandler
    {
        private string line { get; set; }
        private string[] words { get; set; }

        public StringHandler(string line)
        {
            this.line = line;
            this.words = line.Split(' ');
        }

        public bool isContain(string t)
        {            
            foreach (string word in words)
            {
                if (word.ToLower() == t.ToLower())
                    return true;
            }
            return false;
        }

        public int getNumericValue()
        {
            int value;            
            foreach (string word in words)
            {
                if (int.TryParse(word, out value))
                    return value;                    
            }
            return 0;
        }

        public string getStringValue(int index)
        {            
            if (index <= words.Length)
            {
                return words[index];
            }
            else
                return String.Empty;            

        }
    }
}
