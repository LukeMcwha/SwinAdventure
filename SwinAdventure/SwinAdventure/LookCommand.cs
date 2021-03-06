﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] { "look" })
        {

        }

        public override string Execute(Player p, string[] text)
        {
            

            // Check if length of text is 3 or 5 
            if ((text.Length != 1 && text.Length != 3 && text.Length != 5) || text[0] != "look")
                return "I don't know how to look like that";
            // Check if first word is "look" and if length of command is 1
            if (text.Length == 1)
                return p.Location.LongDescription; // print the locations description

            // Check if second work is "at"
            if (text[1] != "at")
                return "What do you want to look at?";

            // text.length == 5 then look in player
            if (text.Length == 3)
            {
                return LookAtIn(text[2], p);
            }
            // text.length == 5 then look in player inventory for bag
            else
            {
                // Fourth word must be "in"
                if (text[3] != "in")
                    return "What do you want to look in?";
                // Find container
                IHaveInventory invent = FetchContainer(p, text[4]);
                if (invent is null)
                    return String.Format("I cannot find the {0}", text[4]);
                return LookAtIn(text[2], invent);
            }

        }

        private IHaveInventory FetchContainer(Player p, string containerID)
        {
            return p.Inventory.Fetch(containerID) as IHaveInventory;
        }

        private string LookAtIn(string thingID, IHaveInventory container)
        {
            // Search for the thing in the container
            GameObject gameObject = container.Locate(thingID);
            if (gameObject is null)
                return String.Format("I cannot find the {0}", thingID);
            else
                return gameObject.LongDescription;
        }
    }
}
