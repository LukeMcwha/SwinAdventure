using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class TakeCommand : Command
    {
        public TakeCommand() : base(new string[] { "take", "get", "pickup" })
        {

        }

        public override string Execute(Player p, string[] text)
        {
            if (text[0] != "take")
                return "Error in TakeCommand";

            if (text.Length == 2)
            {
                Item i = p.Location.Inventory.Take(text[1]);
                if (!(i is null))
                {
                    p.Inventory.Put(i);
                    return String.Format("You have taken the {0} from the {1}", i.Name, p.Location.Name);
                }
                else
                {
                    return String.Format("I cannot find the {0}", text[1]);
                }
            }
            else if(text.Length == 4)
            {
                Item i;
                IHaveInventory invent = p.Locate(text[3]) as IHaveInventory;
                if (!(invent is null))
                {
                    i = invent.Inventory.Take(text[1]);
                    if (!(i is null))
                    {
                        p.Inventory.Put(i);
                        return String.Format("You have taken the {0} from the {1}", i.Name, p.Location.Name);
                    }
                    else
                    {
                        return String.Format("I cannot find the {0} in the {1}", text[1], text[3]);
                    }
                }
                else
                {
                    return String.Format("I cannot find the {0}", text[3]);
                }
            }
            else
            {
                return String.Format("I do not know how to take like that.");
            }
        }
    }
}
