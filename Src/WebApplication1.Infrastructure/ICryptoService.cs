namespace WebApplication1.Infrastructure
{
    /// <summary>
    /// https://qawithexperts.com/article/c-sharp/encrypt-password-decrypt-it-c-console-application-example/169
    /// </summary>
    public interface ICryptoService
    {
        string Decrypt(string CipherText);
        string Encrypt(string PlainText);
    }
}