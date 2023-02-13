using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Heros
{
    public class HeroAttribute
    {
        public int Strength { get; set;}
        public int Dexterity { get; set;}
        public int Intelligence { get; set;}

        public HeroAttribute(int strength , int dexterity, int intelligence) { 
            Strength = strength;
            Dexterity = dexterity;
            Intelligence = intelligence;
        }

        public HeroAttribute addToInstances(HeroAttribute heroAttribute)
        {
            return new HeroAttribute(
                    Strength + heroAttribute.Strength,
                    Dexterity + heroAttribute.Dexterity,
                    Intelligence + heroAttribute.Intelligence
                );
        }

        public void IncreaseByAmount(int strengthAmount , int dexterityAmount , int intelligenceAmount)
        {
            Strength += strengthAmount;
            Dexterity += dexterityAmount;
            Intelligence += intelligenceAmount;
        }
    }
}
