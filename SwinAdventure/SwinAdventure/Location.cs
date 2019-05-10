using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private List<Path> _paths;

        public Location(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            _inventory = new Inventory();
            _paths = new List<Path>();
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
                return this;
            else
                return _inventory.Fetch(id);
        }

        public Path GetPath(string id)
        {
            foreach (Path p in _paths)
            {
                if (p.AreYou(id))
                    return p;
            }
            return null;
        }

        public Inventory Inventory
        {
            get { return _inventory; }
        }

        public List<Path> Paths
        {
            get { return _paths; }
        }
    }
}
