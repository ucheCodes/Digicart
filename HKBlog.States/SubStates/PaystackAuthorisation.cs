using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBlog.States.SubStates
{
    public class PaystackAuthorisation
    {
        public KeyValuePair<bool, string> AuthKeyVal { get;} = new();
        public PaystackAuthorisation(KeyValuePair<bool,string> kvp)
        {
            AuthKeyVal = kvp;
        }
    }
}
