using HKBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBlog.States.SubStates
{
    public class AllWalletsInformation
    {
        public IReadOnlyList<Wallet> Wallets { get; } 
        public IReadOnlyList<AccountNotification> AccountNotifications { get; }
        public AllWalletsInformation(List<Wallet> wallets, List<AccountNotification> notifs)
        {
            Wallets = wallets;
            AccountNotifications = notifs;
        }
    }
}
