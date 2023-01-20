using System.Security.Cryptography;
using CommonExtensions.Cryptography;
using Shouldly;

namespace CommonExtensions.Test.Cryptography;

public class RsaShould
{
    [Fact]
    public void ExtractRsaPrivateKeyPem()
    {
        // Arrange
        var rsa = RSA.Create();
        var privateKey = rsa.ExportRSAPrivateKey();

        // Act
        var result = rsa.ExtractRsaPrivateKeyPem();
        rsa.ImportFromPem(result);

        // Assert
        result.ShouldNotBeNullOrEmpty();
        rsa.ExportRSAPrivateKey().ShouldBe(privateKey);
    }
    
    [Fact]
    public void ExtractRsaPublicKeyPem()
    {
        // Arrange
        var rsa = RSA.Create();
        var publicKey = rsa.ExportRSAPublicKey();

        // Act
        var result = rsa.ExtractRsaPublicKeyPem();
        rsa.ImportFromPem(result);

        // Assert
        result.ShouldNotBeNullOrEmpty();
        rsa.ExportRSAPublicKey().ShouldBe(publicKey);
    }
}