using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBlog.Models
{
    public class EncryptionKeeper
    {
        public string EncryptionId { get; set; } = "";
        public byte[] EncryptionKey { get; set; } = new byte[32];
        public byte[] EncryptionIV { get; set; } = new byte[16];
        public string EncryptedSerializedData { get; set; } = "";
        public DataFrom DataFrom { get; set; } = DataFrom.none;

    }
    public enum DataFrom
    {
        none,wallet,account
    }
}
