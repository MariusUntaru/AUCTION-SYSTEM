namespace AuctionSystem.Api.Controllers
{
    using System;
    using System.Security.Cryptography;
    using System.Web;

    /// <summary>
    /// The account controller.
    /// </summary>
    public partial class AccountController
    {
        private static class RandomOAuthStateGenerator
        {
            private static RandomNumberGenerator random = new RNGCryptoServiceProvider();

            public static string Generate(int strengthInBits)
            {
                const int BitsPerByte = 8;

                if (strengthInBits % BitsPerByte != 0)
                {
                    throw new ArgumentException("strengthInBits must be evenly divisible by 8.", "strengthInBits");
                }

                int strengthInBytes = strengthInBits / BitsPerByte;

                byte[] data = new byte[strengthInBytes];
                random.GetBytes(data);
                return HttpServerUtility.UrlTokenEncode(data);
            }
        }
    }
}