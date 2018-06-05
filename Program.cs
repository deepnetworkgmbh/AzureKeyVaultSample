using System;
using System.Threading.Tasks;
using Microsoft.Azure.KeyVault;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace KeyVaultSample
{
    class Program
    {
        /// <summary>
        /// The URI of the vault we're trying to access
        /// </summary>
        private static readonly string vaultUri = "";

        /// <summary>
        /// Credentials from the app that has access to the vault
        /// </summary>
        private static readonly ClientCredential Credential = new ClientCredential("<ClientId>", "<AuthenticationKey>");

        static void Main(string[] args)
        {
            var keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(GetAccessToken));

            var secret = keyVaultClient.GetSecretAsync(vaultUri, "<Secret>").Result;

            Console.WriteLine($"Your secret is {secret.Value}");
        }

        /// <summary>
        /// Callback method for getting the access token for the given client id / secret
        /// </summary>
        /// <param name="authority"></param>
        /// <param name="resource"></param>
        /// <param name="scope"></param>
        /// <returns></returns>
        public static async Task<string> GetAccessToken(string authority, string resource, string scope)
        {
            var context = new AuthenticationContext(authority, TokenCache.DefaultShared);
            var result = await context.AcquireTokenAsync(resource, Credential);

            return result.AccessToken;
        }
    }
}
