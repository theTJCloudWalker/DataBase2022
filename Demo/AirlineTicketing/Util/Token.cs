namespace AirlineTicketing.Util;
// TODO 完成Token类 对用户登录的验证

/// <summary>
/// Token类
/// </summary>
public class Token {
    public static string PrimaryKey = "Tongji-1907"; // 服务端私钥

    /// <summary>
    /// 生成Token
    /// </summary>
    /// <param name="tokenInfo">用户名 密码</param>
    /// <returns>Token</returns>
    public static string TokenGen(TokenInfo tokenInfo) {
        var payload = new Dictionary<string, dynamic>() {
            {"username", tokenInfo.UserName},
            {"password", tokenInfo.Password}
        };
        return payload.ToString();
    }
}

/// <summary>
/// Token信息
/// </summary>
public class TokenInfo {
    public string UserName { get; set; }
    public string Password { get; set; }

    public TokenInfo(string userName, string password) {
        UserName = userName;
        Password = password;
    }
}