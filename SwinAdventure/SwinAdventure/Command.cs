using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public abstract class Command : IdentifiableObject
    {
        public Command(string[] ids) : base(ids)
        {}

        public abstract string Execute(Player p, string[] text);

        public string[] SanitiseText(string[] text)
        {
            // Sanitise data to all lowercase
            for (int i = 0; i < text.Length; i++)
                text[i] = text[i].ToLower();
            return text;
        }
    }
}
