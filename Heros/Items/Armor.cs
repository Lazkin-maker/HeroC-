using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1.EnumType;
using Assignment1.Heros;

namespace Assignment1.Heros.Items
{
    public class Armor : Item
    {

        public ArmorType Type { get; set; }

        public HeroAttribute ArmoAttribute { get; set; }

        public Armor(string name, int requiredLevel, Slot slot, ArmorType type, HeroAttribute armoAttribute) : base(name, requiredLevel, slot)
        {
            Type = type;
            ArmoAttribute = armoAttribute;
        }
    }
}
