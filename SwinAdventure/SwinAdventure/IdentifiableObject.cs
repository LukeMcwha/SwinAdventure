using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class IdentifiableObject
    {
        private List<string> _identifiers = new List<string>();
        
        public IdentifiableObject(string[] ids)
        {
            foreach (string s in ids)
            {
                _identifiers.Add(s.ToLower());
            }
        }

        public bool AreYou(string s)
        {
            return _identifiers.Contains(s.ToLower());
        }
        
        public void AddIdentifier(string id)
        {
            _identifiers.Add(id.ToLower());
        }

        public string FirstId
        {
            get { return _identifiers[0]; }
        }




    }
}
