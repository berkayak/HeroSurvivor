using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Hero
    {
        public int health { get; set; }
        public int maxHealth { get; set; }
        public int attackPower { get; set; }
        public Position position { get; set; }
    }
}
