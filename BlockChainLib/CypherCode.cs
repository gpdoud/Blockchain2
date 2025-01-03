using System;
using System.Security.Cryptography;
using System.Text;

namespace BlockChainLib;

public class CypherCode {
    public static string Encrypt(string data) {
        using (SHA256 sha256Hash = SHA256.Create()) {
        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(data));
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < bytes.Length; i++) {
            builder.Append(bytes[i].ToString("x2"));
        }
        return builder.ToString();
        }
    }
}
