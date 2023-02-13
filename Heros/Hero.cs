using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Heros
{
    public abstract class Hero
    {
        protected string name;
        protected int level = 1;
        // protected string weapon;
        private Weapon equippedWeapon;
        protected string armor;
        protected List<Weapon> equipments = new List<Weapon>();
        protected List<string> ValidWeaponTypes;
        protected List<string> ValidArmorTypes;

        public HeroAttribute Attribute { get; set; }
        public Weapon weapon { get; set; }
        //public HeroAttribute totalAttribute { get; set; }




        public HeroAttribute totalAttribute { 
        get 
            { HeroAttribute totalAttribute  =   new HeroAttribute(Attribute.Strength, Attribute.Dexterity, Attribute.Intelligence);
            foreach (var item in equipment)
                {
                    if(item.Value is Armor)
                    {
                        Armor armor = (Armor)item.Value;
                        totalAttribute.Strength += armor.ArmoAttribute.Strength;
                        totalAttribute.Dexterity += armor.ArmoAttribute.Dexterity;
                        totalAttribute.Intelligence += armor.ArmoAttribute.Intelligence;
                    }       
                }
            return totalAttribute;
            }
        }

        public virtual int CalculateDamage()
        {
            int damageAttribute = 0;
            switch (this)
            {
                case Mage w:
                    damageAttribute = w.totalAttribute.Intelligence;
                    break;

                case Ranger r:
                    damageAttribute= r.totalAttribute.Dexterity;
                    break;
            }

            int weaponDamage = equippedWeapon != null ? equippedWeapon.Damage : 1;
            return weaponDamage * (1 + damageAttribute / 100);
        }

        protected Dictionary<Slot, Item> equipment;

      
        public string Name { get => name; set => name = value; } 
        public int Level { get => level; set => level = value; }

        public Hero(HeroAttribute attribute) {
            Attribute = attribute;
            equipment = new Dictionary<Slot, Item>
            {
                {Slot.Head, null},
                {Slot.Body, null},
                {Slot.Legs, null},
                {Slot.Weapon, null}
            };
        }

        public Hero(string name) {
            this.name = name;
        }


        public virtual void EquipItem(Item item)
        {
            if(item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            if(item.RequiredLevel > Level)
            {
                throw new InvalidItemException($"{Name}cannot equip {item.Name} because it requires level {item.RequiredLevel}.");
            }
            equipment[item.Slot] = item;
            if(item is Weapon)
            {
                equippedWeapon = (Weapon)item;

            }
        }

        public virtual void EquipArmor(Armor armor)
        {
            if(armor == null)
            {
                throw new ArgumentNullException(nameof(armor));
            }
            if(armor.RequiredLevel > Level)
            {
                throw new InvalidArmorException($"{Name} cannot equip {armor.Name} because it requires level {armor.RequiredLevel}.");
            }

            equipment[armor.Slot] = armor;
        }

       
        public abstract int LevelUp();    
        
        public bool CanEquipItem(Item item)
        {
            return Level >= item.RequiredLevel;
        }
       
    }
}
