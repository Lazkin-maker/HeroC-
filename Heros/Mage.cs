using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Heros
{
    public class Mage : Hero
    {

       
        public Dictionary<Slot, Item> Equipment
        {
            get { return base.equipment; }
            set { base.equipment = value; }
        }
        public Mage(HeroAttribute attribute) : base(attribute) { 
            attribute.Strength = 1;
            attribute.Dexterity = 1;
            attribute.Intelligence = 8;
        }

        

        public override void EquipItem(Item item)
        {

            if (item is Weapon)
            {
                base.EquipItem(item);
               
                Weapon weapon = (Weapon)item;
                if(weapon.Type != Heros.Weapon.WeaponType.Staffs && weapon.Type != Heros.Weapon.WeaponType.Wand) {
                    throw new InvalidItemException($"{Name} cannot equip {item.Name} because it is not an availeble weapon!");
                }
            }
            else if(item is Armor)
            {
                
                Armor armor = (Armor)item;
                base.EquipArmor(armor);
                if (armor.Type != Heros.Armor.ArmorType.Cloth)
                {
                    throw new InvalidArmorException($"{Name} cannot equip {armor.Name} because it is not Cloth");
                }
                Attribute.Strength += armor.ArmoAttribute.Strength;
                Attribute.Dexterity += armor.ArmoAttribute.Dexterity;
                Attribute.Intelligence += armor.ArmoAttribute.Intelligence;


            }
        }
        public override int LevelUp()
        {
           level = level + 1;
           Attribute.Strength = Attribute.Strength + 1;
           Attribute.Dexterity = Attribute.Dexterity + 1;
           Attribute.Intelligence = Attribute.Intelligence + 5;
           return level;  
        }
    }
}
