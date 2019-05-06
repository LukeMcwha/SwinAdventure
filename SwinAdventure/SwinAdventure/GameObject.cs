using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class GameObject : IdentifiableObject
    {
        private string _name;
        private string _desc;

        public GameObject(string[] ids, string name, string desc) : base (ids)
        {
            _name = name.ToLower();
            _desc = desc;
        }

        public string Name
        {
            get { return _name; }
        }

        public string ShortDescription
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("a ");
                sb.Append(_name);
                sb.Append(' ');
                sb.Append("(");
                sb.Append(FirstId);
                sb.Append(")");

                return sb.ToString();
            }
        }

        public virtual string LongDescription
        {
            get { return _desc; }
        }
    }
}
