using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class MoveCommand : Command
    {
        public MoveCommand() : base(new string[] { "move", "go", "head", "leave"})
        {

        }

        public override string Execute(Player p, string[] text)
        {
            // Check whether text is a valid length
            if (text.Length > 2 || text.Length == 0)
                return "I don't know how to move like that.";

            text = SanitiseText(text);  // Sanitise text input
            Location currentLocation = p.Location;  // get players location

            // check if first word is move. otherwise this is an error
            if (text[0] != "move")
                return "Error in move command";

            // get the next path from the location
            Path nextPath = currentLocation.GetPath(text[1]);

            if (nextPath is null) // There is no path
                return "Invalid path identifier";
            else
            {
                nextPath.MovePlayer(p); // There is a path, path moves player to its location
                return nextPath.LongDescription;    // returns paths description
            }
        }
    }
}
