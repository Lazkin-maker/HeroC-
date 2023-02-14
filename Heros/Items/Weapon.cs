using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1.EnumType;

namespace Assignment1.Heros.Items
{
    public class Weapon : Item
    {
        public WeaponType Type { get; set; }
        public int Damage { get; set; }

        public Weapon(string name, int requiredLevel, Slot slot, WeaponType type, int damage) : base(name, requiredLevel, Slot.Weapon)
        {
            Damage = damage;
            Type = type;
        }

        public enum WeaponType
        {
            Axes,
            Bows,
            Daggers,
            Hammers,
            Staffs,
            Swords,
            Wand
        }
    }
}
