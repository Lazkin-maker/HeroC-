using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Heros
{
    public class Armor : Item
    {
      
        public ArmorType Type { get; set; }

        public HeroAttribute ArmoAttribute { get; set; }

        public Armor(string name, int requiredLevel , Slot slot, ArmorType type, HeroAttribute armoAttribute) : base(name, requiredLevel, slot) 
        {
            
            Type = type;
            ArmoAttribute = armoAttribute;
        }

        public enum ArmorType
        {
            Cloth,
            Leather,
            Mail,
            Plate
        }
    }
}
