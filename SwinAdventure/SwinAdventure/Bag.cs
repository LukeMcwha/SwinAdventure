using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Bag : Item, IHaveInventory
    {
        private Inventory _inventory;

        public Bag(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            _inventory = new Inventory();
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
                return this;
            else
                return _inventory.Fetch(id);
        }

        public override string LongDescription
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("In the ");
                sb.Append(Name);
                sb.Append(" you can see:");
                sb.Append(Environment.NewLine);
                sb.Append(_inventory.ItemList);

                return sb.ToString();
            }
        }

        public Inventory Inventory
        {
            get { return _inventory; }
        }
    }
}
