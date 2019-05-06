using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            // Player info to create player.
            Console.WriteLine("What is your characters name?");
            string name = Console.ReadLine();
            Console.WriteLine("What is your characters description?");
            string desc = Console.ReadLine();

            // Create items and player
            Item sword = new Item(new string[] { "sword" }, "Iron Sword", "Long gleaming weapon of the middle ages.");
            Item shield = new Item(new string[] { "shield" }, "Wooden Shield", "Strong wooden shield that takes the brunt of the damage.");
            Item compass = new Item(new string[] { "compass" }, "Compass", "A navigational tool that will always lead you in the right direction.");
            Bag bag = new Bag(new string[] { "bag" }, "Leather bag", "Storage bag to bring items on a long journey.");
            Player player = new Player(name, desc);

            // Add items to bag and to player
            player.Inventory.Put(sword);
            player.Inventory.Put(shield);
            player.Inventory.Put(bag);
            bag.Inventory.Put(compass);

            // Create commands
            LookCommand lcmd = new LookCommand(new string[] { "look" });


            string cmd = "";
            while (cmd != "end")
            {
                Console.Write("Command -> ");
                cmd = Console.ReadLine();
                Console.WriteLine(lcmd.Execute(player, cmd.Split(' ')));
            }
        }
    }
}
