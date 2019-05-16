using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class PutCommand : Command
    {
        public PutCommand() : base(new string[] { "put", "drop" })
        {

        }

        public override string Execute(Player p, string[] text)
        {
            Item i;
            IHaveInventory invent;

            if (text.Length == 2)
            {
                invent = p.Location;
                i = p.Inventory.Take(text[1]);

                if (!(i is null))
                {
                    invent.Inventory.Put(i);
                    return String.Format("You have put the {0} in the {1}", i.Name, invent.Name);
                }
                else
                    return String.Format("I cannot find the {0}", text[1]);
            }
            else if (text.Length == 4)
            {
                i = p.Inventory.Take(text[1]);
                invent = FetchContainer(p, text[3]);
                if (!(i is null))
                {
                    invent.Inventory.Put(i);
                    return String.Format("You have put the {0} in the {1}", i.Name, invent.Name);
                }
                else
                    return String.Format("I cannot find the {0}", text[1]);
            }
            else
            {
                return "I don't know how to put like that";
            }

        }

        private IHaveInventory FetchContainer(Player p, string containerID)
        {
            return p.Inventory.Fetch(containerID) as IHaveInventory;
        }
    }
}
