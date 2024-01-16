namespace HKBlog.Models
{
    public interface IEncryptionHelper
    {
        string Decrypt(string encryptedData, byte[] key, byte[] IV);
        (string encryptedResult, byte[] key, byte[] IV) Encrypt(string data);
    }
}