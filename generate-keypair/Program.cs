using System.Text;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;


void Main()
{
    RsaKeyPairGenerator r = new RsaKeyPairGenerator();
    r.Init(new KeyGenerationParameters(new SecureRandom(), 1024));
    AsymmetricCipherKeyPair keys = r.GenerateKeyPair();

    var DkimPrivateKey = ToPem(keys.Private);
    var DkimPublicKey = ToPem(keys.Public);


    StringBuilder sb = new StringBuilder();
    sb.AppendLine();
    sb.AppendLine($"DkimPrivateKey:\n{DkimPrivateKey}");
    sb.AppendLine();
    sb.AppendLine($"DkimPublicKey:\n{DkimPublicKey}");

    Console.WriteLine(sb.ToString());
}

string ToPem(object obj)
{
    StringWriter sw = new StringWriter();
    PemWriter pem = new PemWriter(sw);
    pem.WriteObject(obj);
    return sw.ToString();
}

Main();