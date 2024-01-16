using HKBlog.Models;

namespace HKBlog.Controllers
{
    public interface IAccountController
    {
        //Task<bool> CreateWallet(Wallet wallet);
        Task<bool> EncryptData(string SerializedData, string encryptionId, DataFrom dataFrom);
        Task<EncryptionKeeper> GetEncryptedData(string encId);
        Task<List<T>> GetAndDecryptAllEncryptedData<T>(DataFrom dataFrom);
        int GetEncryptedDataCount();
        Task<bool> EncryptedDataExists(string encId);
        Task<bool> CreateAccountNotification(AccountNotification notif);
        Task<List<AccountNotification>> GetAccountNotifications(string userId);
        Task<bool> CreateAccountNumber(AccountNumber number);
        Task<List<AccountNumber>> GetAccountNumbers();
    }
}