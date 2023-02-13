using static System.Net.Mime.MediaTypeNames;

namespace Assignment1.Heros
{
    internal class Program
    {
        static void Main(string[] args)
        {
          
            var att = new HeroAttribute(default, default, default);
            var mage = new Mage(att);
            

            Console.WriteLine(mage.Attribute.Intelligence);
            var range = new Ranger(att);
            //Console.WriteLine(range.Attribute.Dexterity);

            var newWeapon = new Weapon("Common Axe", 1, Slot.Weapon,Weapon.WeaponType.Bows, 3);

            Console.WriteLine(newWeapon.Slot);

            var newArmor = new Armor("Common Plate Chest" , 1 , Slot.Body , Armor.ArmorType.Mail, new HeroAttribute(1, 0 , 0));

            range.EquipItem(newWeapon);
            range.EquipItem(newArmor);
         
            //mage.EquipItem(newWeapon);
            //mage.EquipItem(newArmor);

            Console.WriteLine("Equipment of " + range.Name + ":");
            foreach (KeyValuePair<Slot, Item> entry in range.Equipment)
            {
                Console.WriteLine("Slot: " + entry.Key + ", Item: " + (entry.Value != null ? entry.Value.Name : "Empty"));
            }

            Console.WriteLine("This is total Attribute : ");

            Console.WriteLine(range.totalAttribute.Dexterity);


            Console.WriteLine("This is Hero's damage : ");
            Console.WriteLine(range.CalculateDamage());

            //mage.LevelUp();
           
            /*Console.WriteLine(mage.Attribute.Strength);*/

        }
    }
}