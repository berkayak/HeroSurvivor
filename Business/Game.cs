using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Game
    {
        private const string KEYWORD_RESOURCES = "resources";
        private const string KEYWORD_HERO = "hero";
        private const string KEYWORD_ATTACK = "attack";
        private const string KEYWORD_HP = "hp";
        private const string KEYWORD_ENEMY = "enemy";
        private const string KEYWORD_POSITION = "position";

        private const string OUTPUT_STARTED = "Hero started journey with {0} HP!";
        private const string OUTPUT_HERO_DEFEATED = "Hero defeated {0} with {1} HP remaining";
        private const string OUTPUT_HERO_SURVİVED = "Hero Survived!";
        private const string OUTPUT_HERO_DEAD = "Hero is Dead!! Last seen at position {0}!!";
        private const string OUTPUT_FACTOR_DEFEATED = "{0} defeated Hero with {1} HP remaining";


        public List<string> inputLines { get; set; }
        public List<string> outputLines { get; set; }
        public Hero hero { get; set; }
        public Factor resources { get; set; }
        public List<Factor> factors { get; set; }
        public FactorTypes factorTypes { get; set; }
        public StringHandler stringHandler { get; set; }

        public bool StartGame()
        {
            factorTypes = new FactorTypes();
            factors = new List<Factor>();
            resources = new Factor();
            hero = new Hero() { position = new Position() { xValue = 0 } };
            outputLines = new List<string>();

            try
            {
                setGameModel();
                playGame();
                return true;
            }
            catch (Exception ex)
            {
                outputLines.Add("Error: " + ex.Message);
                outputLines.Add("Inner Exception: " + ex.InnerException);
                return false;          
            }
           
        }

        /// <summary>
        /// Text dosyasından aldığıı satırları programa model olarak atar
        /// </summary>
        private void setGameModel()
        {
            foreach (string line in inputLines)
            {
                stringHandler = new StringHandler(line);
                if (stringHandler.isContain(KEYWORD_RESOURCES))
                {
                    int position = stringHandler.getNumericValue();
                    factorTypes.AddFactorType(new FactorType() { Name = KEYWORD_RESOURCES });
                    resources.factorType = factorTypes.getFactorTypeByName(KEYWORD_RESOURCES);
                    resources.position = new Position() { xValue = position };
                }
                else if (stringHandler.isContain(KEYWORD_HERO) && stringHandler.isContain(KEYWORD_HP))
                {
                    int hp = stringHandler.getNumericValue();
                    hero.maxHealth = hero.health = hp;
                }
                else if (stringHandler.isContain(KEYWORD_HERO) && stringHandler.isContain(KEYWORD_ATTACK))
                {
                    int attack = stringHandler.getNumericValue();
                    hero.attackPower = attack;
                }
                else if (stringHandler.isContain(KEYWORD_ENEMY))
                {
                    string name = stringHandler.getStringValue(0);
                    if (factorTypes.getFactorTypeByName(name) == null)
                    {
                        factorTypes.AddFactorType(new FactorType() { Name = name, type = KEYWORD_ENEMY });
                    }
                }
                else if (stringHandler.isContain(KEYWORD_HP) && !stringHandler.isContain(KEYWORD_HERO))
                {
                    int hp = stringHandler.getNumericValue();
                    string name = stringHandler.getStringValue(0);
                    if (factorTypes.getFactorTypeByName(name) != null)
                    {
                        factorTypes.getFactorTypeByName(name).maxHealth = hp;
                    }
                }
                else if (stringHandler.isContain(KEYWORD_ATTACK) && !stringHandler.isContain(KEYWORD_HERO))
                {
                    int attack = stringHandler.getNumericValue();
                    string name = stringHandler.getStringValue(0);
                    if (factorTypes.getFactorTypeByName(name) != null)
                    {
                        factorTypes.getFactorTypeByName(name).attackPower = attack;
                    }
                }
                else if (stringHandler.isContain(KEYWORD_POSITION))
                {
                    foreach (FactorType factorType in factorTypes.factorTypes)
                    {
                        if (stringHandler.isContain(factorType.Name))
                        {
                            Factor f = new Factor();
                            f.position = new Position() { xValue = stringHandler.getNumericValue() };
                            f.health = factorType.maxHealth;
                            f.factorType = factorType;
                            factors.Add(f);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Hazırlanan modeller ile oyun algoritması burada gerçekleşir
        /// </summary>
        private void playGame()
        {
            int target = resources.position.xValue;
            outputLines.Add(String.Format(OUTPUT_STARTED, hero.health.ToString()));

            for (int currentPosition = 0; currentPosition < target + 1; currentPosition++)
            {
                Factor f = CheckPosition(currentPosition);
                if (f == null) continue;
                else if (f.factorType.type == KEYWORD_ENEMY)
                {
                    f = Fight(hero, f);
                    if (hero.health > 0)
                    {
                        outputLines.Add(String.Format(OUTPUT_HERO_DEFEATED, f.factorType.Name, hero.health.ToString()));
                    }
                    else if (f.health > 0)
                    {
                        outputLines.Add(String.Format(OUTPUT_FACTOR_DEFEATED, f.factorType.Name, f.health.ToString()));
                        outputLines.Add(String.Format(OUTPUT_HERO_DEAD, currentPosition.ToString()));
                        break;
                    }
                }
            }

            if (hero.health > 0)
            {
                outputLines.Add(String.Format(OUTPUT_HERO_SURVİVED));
            }
        }

        private Factor CheckPosition(int position)
        {
            foreach (Factor factorItem in factors)
            {
                if (factorItem.position.xValue == position)
                {
                    return factorItem;
                }
            }
            return null;
        }

        private Factor Fight(Hero hero, Factor factor)
        {
            int heroAttacks = (factor.health % hero.attackPower == 0 ? factor.health / hero.attackPower : (factor.health / hero.attackPower) + 1);
            int factorAttacks = (hero.health % factor.factorType.attackPower == 0 ? hero.health / factor.factorType.attackPower : (hero.health / factor.factorType.attackPower) + 1);
            if(heroAttacks <= factorAttacks)
            {
                hero.health = hero.health - factor.factorType.attackPower * heroAttacks;
                return factor;
            }
            else
            {
                factor.health = factor.health - hero.attackPower * factorAttacks;
                hero.health = 0;
                return factor;
            }
        }

    }
}
