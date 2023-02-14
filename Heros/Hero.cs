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
    public abstract class Hero
    {
        protected string name;
        protected int level = 1;
        // protected string weapon;
        private Weapon equippedWeapon;
        protected string armor;
        protected List<Weapon> equipments = new List<Weapon>();
        protected List<WeaponType> ValidWeaponTypes;
        protected List<ArmorType> ValidArmorTypes;

        public HeroAttribute Attribute { get; set; }
        public Weapon weapon { get; set; }

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


        public Hero(string name) {
            Name = name;
            equipment = new Dictionary<Slot, Item>
            {
                {Slot.Head, null},
                {Slot.Body, null},
                {Slot.Legs, null},
                {Slot.Weapon, null}
            };
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

        public virtual void display()
        {
            try
            {
                StringBuilder heroInfo = new StringBuilder();

                heroInfo.AppendLine("Hero's Information : ");
                heroInfo.AppendLine("The name of Hero :" + (this.name != null ? this.name : "Empty"));
                heroInfo.AppendLine("The Class name of Hero : " + (this.GetType().Name != null ? this.GetType().Name : "Empty"));
                heroInfo.AppendLine("Hero Level : " + (this.Level != null ? this.Level : "Empty"));
                heroInfo.AppendLine("Total Strength : " + (this.totalAttribute.Strength != null ? this.totalAttribute.Strength : "Empty"));
                heroInfo.AppendLine("Total Dexterity : " + (this.totalAttribute.Dexterity != null ? this.totalAttribute.Dexterity : "Empty"));
                heroInfo.AppendLine("Total Intelligence : " + (this.totalAttribute.Intelligence != null ? this.totalAttribute.Intelligence : "Empty"));
                heroInfo.AppendLine("Hero's Damage : " + (this.CalculateDamage() != null ? this.CalculateDamage() : "Empty"));

                Console.WriteLine(heroInfo.ToString());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

    }
}
