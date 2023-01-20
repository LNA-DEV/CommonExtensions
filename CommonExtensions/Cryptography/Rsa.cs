using System;
using System.Security.Cryptography;

namespace CommonExtensions.Cryptography
{
    /// <summary>
    ///     Extension Methods based on the RSA class.
    /// </summary>
    public static class Rsa
    {
        /// <summary>
        ///     Extract PrivateKey of RSA class in PEM format.
        /// </summary>
        /// <param name="rsa">The RSA class of which the key should be extracted.</param>
        /// <returns>RSA PrivateKey in PEM format.</returns>
        public static string ExtractPrivateKeyPem(this RSA rsa)
        {
            const string beginRsaPrivateKey = "-----BEGIN RSA PRIVATE KEY-----";
            const string endRsaPrivateKey = "-----END RSA PRIVATE KEY-----";
            var keyPrv = Convert.ToBase64String(rsa.ExportRSAPrivateKey());
            var extractPrivateKey = $"{beginRsaPrivateKey}\n{keyPrv}\n{endRsaPrivateKey}";

            return extractPrivateKey;
        }

        /// <summary>
        ///     Extract PublicKey of RSA class in PEM format.
        /// </summary>
        /// <param name="rsa">The RSA class of which the key should be extracted.</param>
        /// <returns>RSA PublicKey in PEM format.</returns>
        public static string ExtractPublicKeyPem(this RSA rsa)
        {
            const string beginRsaPublicKey = "-----BEGIN RSA PUBLIC KEY-----";
            const string endRsaPublicKey = "-----END RSA PUBLIC KEY-----";
            var base64PublicKey = Convert.ToBase64String(rsa.ExportRSAPublicKey());
            var publicKey = $"{beginRsaPublicKey}\n{base64PublicKey}\n{endRsaPublicKey}";
            return publicKey;
        }
    }
}