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
        public Dictionary<Slot, Item> Equipment
        {
            get { return base.equipment; }
            set { base.equipment = value; }
        }

        public Ranger(HeroAttribute attribute) : base(attribute) { 
            attribute.Strength = 1;
            attribute.Dexterity= 7;
            attribute.Intelligence= 1;
        }


        public override void EquipItem(Item item)
        {
            base.EquipItem(item);
           if(item is Weapon)
            {
                Weapon weapon = (Weapon)item;
                if(weapon.Type != Weapon.WeaponType.Bows) {
                    throw new InvalidItemException($"{Name} cannot equip {item.Name} because it is not an availeble weapon!");
                }
            }
           else if(item is Armor)
            {
                Armor armor = (Armor)item;
                base.EquipArmor(armor);
                if (armor.Type != Armor.ArmorType.Leather && armor.Type != Armor.ArmorType.Mail)
                {
                    throw new InvalidArmorException($"{Name} cannot equip {armor.Name} because it is not Leather type nor Mail!");
                }
              /*Attribute.Strength += armor.ArmoAttribute.Strength;
                Attribute.Dexterity += armor.ArmoAttribute.Dexterity;
                Attribute.Intelligence += armor.ArmoAttribute.Intelligence;*/
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
    }
}
