using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Factor
    {
        public FactorType factorType { get; set; }
        public int health { get; set; }
        public Position position { get; set; }
    }

    public class FactorType
    {
        public string Name { get; set; }
        public string type { get; set; }
        public int maxHealth { get; set; }
        public int attackPower { get; set; }
        
    }

    public class FactorTypes
    {
        public List<FactorType> factorTypes { get; set; }

        public FactorTypes()
        {
            this.factorTypes = new List<FactorType>();
        }
        
        public void AddFactorType(FactorType f)
        {
            factorTypes.Add(f);
        }
        

        public FactorType getFactorTypeByName(string factorName)
        {
            if (factorTypes != null && factorTypes.Count() > 0)
            {
                foreach (FactorType item in factorTypes)
                {
                    if (item.Name == factorName)
                        return item;
                }
            }
            return null;
            
        }

    }
}
