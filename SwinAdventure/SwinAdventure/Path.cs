using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Path : GameObject
    {
        private Location _location;

        public Path(string[] ids, string name, string desc, Location location) : base(ids, name, desc)
        {
            _location = location;
        }

        public void MovePlayer(Player p)
        {
            p.MoveLocation(_location);
        }

        public override string LongDescription
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(String.Format("You head {0}", FirstId));
                sb.Append(base.LongDescription);
                sb.Append(String.Format("You have arrived in a {0}", _location.Name));
                return sb.ToString();
            }
        }
    }
}
