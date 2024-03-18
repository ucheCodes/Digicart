using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBlog.States.SubStates
{
    public class ShowCartClicker
    {
        public bool ShowCart { get; set; } = false;
        public ShowCartClicker(bool showCart)
        {
            ShowCart = showCart;
        }
    }
}
