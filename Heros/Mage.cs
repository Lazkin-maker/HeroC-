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
    public class Mage : Hero
    {

       public List<WeaponType> MageValidWeapons
        {
            get { return base.ValidWeaponTypes; }
            set { base.ValidWeaponTypes = new List<WeaponType> { WeaponType.Staffs, WeaponType.Wand }; }
        }

        public List<ArmorType> MageValidArmor
        {
            get { return base.ValidArmorTypes; }
            set { base.ValidArmorTypes = value; }   
        }

        public Dictionary<Slot, Item> Equipment
        {
            get { return base.equipment; }
            set { base.equipment = value; }
        }
        public Mage(string name) : base(name) {     
            Attribute = new HeroAttribute(1, 1, 8);

            MageValidWeapons = new List<WeaponType> { WeaponType.Staffs, WeaponType.Wand };
            ValidArmorTypes = new List<ArmorType> { ArmorType.Cloth };
        }

        public override void EquipItem(Item item)
        {

            if (item is Weapon)
            {
                base.EquipItem(item);
               
                Weapon weapon = (Weapon)item;
                if( !MageValidWeapons.Contains(weapon.Type)) {
                    throw new InvalidItemException($"{Name} cannot equip {item.Name} because it is not an availeble weapon!");
                }
            }
            else if(item is Armor)
            {
                
                Armor armor = (Armor)item;
                base.EquipArmor(armor);
                if (MageValidArmor.Contains(armor.Type))
                {
                    throw new InvalidArmorException($"{Name} cannot equip {armor.Name} because it is not Cloth");
                }
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

        public override void display()
        {
            base.display();
        }
    }
}
