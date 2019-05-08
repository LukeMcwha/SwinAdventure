using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Path : IdentifiableObject
    {
        private Location _location;

        public Path(string[] ids, Location location) : base(ids)
        {
            _location = location;
        }

        public void MovePlayer()
        {

        }
    }
}
