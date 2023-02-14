using Assignment1.EnumType;
using Assignment1.Exceptions;
using Assignment1.Heros.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Heros
{
    public class Ranger: Hero
    {
        public List<WeaponType> RangerValidWeapons
        {
            get { return base.ValidWeaponTypes; }
            set { base.ValidWeaponTypes = value; }
        }

        public List<ArmorType> RangerValidArmor
        {
            get { return base.ValidArmorTypes; }
            set { base.ValidArmorTypes = new List<ArmorType> { ArmorType.Leather, ArmorType.Mail }; }
        }

        public Dictionary<Slot, Item> Equipment
        {
            get { return base.equipment; }
            set { base.equipment = value; }
        }

        public Ranger(string name) : base(name) {
            Attribute = new HeroAttribute(1, 7, 1);
            RangerValidWeapons = new List<WeaponType>() { WeaponType.Bows };
            RangerValidArmor = new List<ArmorType>() { ArmorType.Leather, ArmorType.Mail };
        }


        public override void EquipItem(Item item)
        {
           base.EquipItem(item);
           if(item is Weapon)
            {
                Weapon weapon = (Weapon)item;
                if(!RangerValidWeapons.Contains(weapon.Type)) {
                    throw new InvalidItemException($"{Name} cannot equip {item.Name} because it is not an availeble weapon!");
                }
            }
           else if(item is Armor)
            {
                Armor armor = (Armor)item;
                base.EquipArmor(armor);
                if (!ValidArmorTypes.Contains(armor.Type))
                {
                    throw new InvalidArmorException($"{Name} cannot equip {armor.Name} because it is not Leather type nor Mail!");
                }

            }
        }
        public override int LevelUp()
        {
             level = level + 1;
             Attribute.Strength = Attribute.Strength + 1;
             Attribute.Dexterity = Attribute.Dexterity + 5;
             Attribute.Intelligence = Attribute.Intelligence + 1;
             return level;
        }

        public override void display()
        {
            base.display();
        }
    }
}
