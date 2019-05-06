using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Player : GameObject
    {
        private Inventory _inventory;

        public Player(string name, string desc) : base(new string[] { "me", "inventory" }, name, desc)
        {
            _inventory = new Inventory();
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id.ToLower()))
            {
                return this;
            }
            else
            {
                return _inventory.Fetch(id.ToLower());
            }
        }

        public override string LongDescription
        {
            get
            {
                return "";
            }
        }

        public Inventory Inventory
        {
            get { return _inventory; }
        }
            
    }
}
