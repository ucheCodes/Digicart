using HKBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBlog.States.SubStates
{
    public class Notifications
    {
        public IReadOnlyList<AccountNotification> Data { get;}
        public Notifications(List<AccountNotification> data)
        {
            Data = data;
        }
    }
}
