using HKBlog.Database;
using HKBlog.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBlog.Controllers
{
    public class AccountController : IAccountController
    {
        private readonly IDatabase database;
        private readonly IEncryptionHelper encryptionHelper;
        public AccountController(IDatabase database, IEncryptionHelper encryptionHelper)
        {
            this.database = database;
            this.encryptionHelper = encryptionHelper;
        }
        public async Task<bool> EncryptData(string SerializedData, string encryptionId,DataFrom dataFrom)
        {
            var encrypted = encryptionHelper.Encrypt(SerializedData);
            var encryptionInfo = new EncryptionKeeper()
            {
                EncryptionId = encryptionId,
                EncryptionKey = encrypted.key,
                EncryptionIV = encrypted.IV,
                EncryptedSerializedData = encrypted.encryptedResult,
                DataFrom = dataFrom
            };
            string key = JsonConvert.SerializeObject(encryptionInfo.EncryptionId);
            string value = JsonConvert.SerializeObject(encryptionInfo);
            bool isAdded = await database.Create("EncryptionKeeper", key, value);
            return isAdded;
        }
        public async Task<EncryptionKeeper> GetEncryptedData(string encId)
        {
            EncryptionKeeper encDataResult = new EncryptionKeeper();
            string key = JsonConvert.SerializeObject(encId);
            var data = await database.Read("EncryptionKeeper", key);
            if (!string.IsNullOrEmpty(data.Value))
            {
                var encData = JsonConvert.DeserializeObject<EncryptionKeeper>(data.Value);
                if (encData != null)
                {
                    encDataResult = encData;
                }
            }
            return encDataResult;
        }
        public async Task<bool> EncryptedDataExists(string encId)
        {
            string key = JsonConvert.SerializeObject(encId);
            var info = await database.Exists("EncryptionKeeper", key);
            return info;
        }
        public async Task<List<T>> GetAndDecryptAllEncryptedData<T>(DataFrom dataFrom)
        {
            List<T> allDecryptedData = new List<T>();
            var data = await database.ReadAll("EncryptionKeeper");
            if (data != null && data.Count() > 0)
            {
                foreach (var encData in data)
                {
                    var ed = JsonConvert.DeserializeObject<EncryptionKeeper>(encData.Value);
                    if (ed != null && ed.DataFrom.Equals(dataFrom))
                    {
                        string decrypted = encryptionHelper.Decrypt(ed.EncryptedSerializedData, ed.EncryptionKey, ed.EncryptionIV);
                        if (!string.IsNullOrEmpty(decrypted))
                        {
                            var mainData = JsonConvert.DeserializeObject<T>(decrypted)!;
                            allDecryptedData.Add(mainData);
                        }
                    }
                }
            }
            return allDecryptedData;
        }
        public int GetEncryptedDataCount()
        {
            var data = database.ReadAll("EncryptionKeeper");
            if (data != null)
            {
                return data.Result.Count();
            }
            return 0;
        }
        public async Task<bool> CreateAccountNotification(AccountNotification notif)
        {
            string key = JsonConvert.SerializeObject(notif.Id);
            string value = JsonConvert.SerializeObject(notif);
            bool isAdded = await database.Create("AccountNotification", key, value);
            return isAdded;
        }
        public async Task<List<AccountNotification>> GetAccountNotifications(string userId)
        {
            List<AccountNotification> accountNotifications = new List<AccountNotification>();
            var data = await database.ReadAll("AccountNotification");
            if (data != null && data.Count() > 0)
            {
                foreach (var acct in data)
                {
                    var account = JsonConvert.DeserializeObject<AccountNotification>(acct.Value);
                    if (account != null && account.UserId.Equals(userId))
                    {
                        accountNotifications.Add(account);
                    }
                    else if (account != null && userId.Equals("admin"))
                    {
                        accountNotifications.Add(account);
                    }
                }
            }
            return accountNotifications;

        }
        public async Task<bool> CreateAccountNumber(AccountNumber number)
        {
            string key = JsonConvert.SerializeObject(number.Id);
            string value = JsonConvert.SerializeObject(number);
            bool isAdded = await database.Create("AccountNumber", key, value);
            return isAdded;
        }
        public async Task<List<AccountNumber>> GetAccountNumbers()
        {
            List<AccountNumber> accountNumbers = new List<AccountNumber>();
            var data = await database.ReadAll("AccountNumber");
            if (data != null && data.Count() > 0)
            {
                foreach (var acct in data)
                {
                    var account = JsonConvert.DeserializeObject<AccountNumber>(acct.Value);
                    if (account != null)
                    {
                        accountNumbers.Add(account);
                    }
                }
            }
            return accountNumbers;

        }
    }
}
