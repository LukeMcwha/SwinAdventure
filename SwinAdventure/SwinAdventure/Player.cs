﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
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
                StringBuilder sb = new StringBuilder();
                sb.Append(base.LongDescription);
                sb.Append(Environment.NewLine);
                sb.Append("You are carrying:");
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
