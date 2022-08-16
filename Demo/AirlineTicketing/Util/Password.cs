using System.Security.Cryptography;

namespace AirlineTicketing.Util; 

public static class Password {
    /// <summary>
    /// SHA256加密密码
    /// </summary>
    /// <param name="passWord">明文密码</param>
    /// <returns>加密后的密码</returns>
    public static string EncryptPassword(string passWord) {
        var sha256 = SHA256.Create();
        var hash = sha256.ComputeHash(System.Text.Encoding.Unicode.GetBytes(passWord));
        var res = Convert.ToHexString(hash);
        return res;
    }
}