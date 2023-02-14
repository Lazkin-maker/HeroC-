using Assignment1.EnumType;
using Assignment1.Heros.Items;
using static System.Net.Mime.MediaTypeNames;

namespace Assignment1.Heros
{
    internal class Program
    {
        static void Main(string[] args)
        {
          
          
            var mage = new Mage("MAGE NAME COOL"); // we should change the constructor to add name of Hero!!
            

            Console.WriteLine(mage.Attribute.Intelligence);
            var range = new Ranger("RANGER NAME COOOOOL");
          

            var newWeapon = new Weapon("Common Axe", 1, Slot.Weapon,WeaponType.Bows, 3);

            Console.WriteLine(newWeapon.Slot);

            var newArmor = new Armor("Common Plate Chest" , 1 , Slot.Body , ArmorType.Leather, new HeroAttribute(1, 3 , 1));

            range.EquipItem(newWeapon);

            Console.WriteLine("Before equip armor : ");
            Console.WriteLine(range.totalAttribute.Dexterity);
            range.EquipItem(newArmor);

            Console.WriteLine("After equip armor : ");
            Console.WriteLine(range.totalAttribute.Dexterity);

            //mage.EquipItem(newWeapon);
            //mage.EquipItem(newArmor);

            Console.WriteLine("Equipment of " + range.Name + ":");
            foreach (KeyValuePair<Slot, Item> entry in range.Equipment)
            {
                Console.WriteLine("Slot: " + entry.Key + ", Item: " + (entry.Value != null ? entry.Value.Name : "Empty"));
            }

            Console.WriteLine("This is Hero's damage : ");
            Console.WriteLine(range.CalculateDamage());

         
            range.display();

           /* range.LevelUp();

            range.display();*/
        }
    }
}