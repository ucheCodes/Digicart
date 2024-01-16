using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBlog.Models
{
    public class Wallet
    {
        public string UserId { get; set; } = "";
        public string WalletId { get; set; } = "";
        public double Balance { get; set; }
        public string EncryptionId { get; set; } = "";
    }
}
