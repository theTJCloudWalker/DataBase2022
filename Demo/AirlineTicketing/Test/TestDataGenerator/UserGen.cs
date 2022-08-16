using System.Security.Cryptography;
using AirlineTicketing.Model;
using Xunit;
using Xunit.Abstractions;

namespace AirlineTicketing.Test.TestDataGenerator;

/// <summary>
/// 生成用户数据
/// </summary>
public class UserGen {
    private readonly ITestOutputHelper _testOutputHelper;

    public UserGen(ITestOutputHelper testOutputHelper) {
        _testOutputHelper = testOutputHelper;
    }

    /// <summary>
    /// 生成用户Id
    /// </summary>
    /// <returns>32位uuid</returns>
    public string UserIdGen() {
        var guid = Guid.NewGuid();
        return guid.ToString();
    }

    /// <summary>
    /// 生成用户密码
    /// </summary>
    /// <returns>SHA256 64位十六进制数</returns>
    public string PasswordGen() {
        var random = new Random(DateTime.Now.Millisecond);
        var buffer = new byte[16];
        random.NextBytes(buffer);
        Console.WriteLine($"password = {buffer}");
        // 加密
        var sha256 = SHA256.Create();
        var res = Convert.ToHexString(sha256.ComputeHash(buffer));
        return res;
    }

    /// <summary>
    /// 生成用户电话号码
    /// </summary>
    /// <returns>11位 电话号码</returns>
    public string PhoneNumberGen() {
        var random = new Random(DateTime.Now.Millisecond);
        var telStarts =
            "134,135,136,137,138,139,150,151,152,157,158,159,130,131,132,155,156,133,153,180,181,182,183,185,186,176,187,188,189,177,178"
                .Split(",");

        var n = random.Next(10, 1000);
        var index = random.Next(0, telStarts.Length - 1);
        var first = telStarts[index];
        var second = (random.Next(100, 888) + 10000).ToString()[1..];
        var third = (random.Next(1, 9100) + 10000).ToString()[1..];
        return first + second + third;
    }

    /// <summary>
    /// 生成用户身份证号
    /// </summary>
    /// <returns>18位身份证号</returns>
    public string PassengerIdGen() {
        var start = new string[]
            {"500101", "500102", "500103", "500104", "500105", "500106", "500107", "500108"};
        var random = new Random(DateTime.Now.Millisecond);
        //PIN = District + Year(50-92) + Month(01-12) + Date(01-30) + Seq(001-600)
        var pinCode =
            $"{start[random.Next(0, 8)]}19{random.Next(50, 92)}{random.Next(1, 12):00}{random.Next(1, 30):00}{random.Next(1, 600):000}";

        var chrPinCode = pinCode.ToCharArray();
        //校验码字符值
        var chrVerify = new char[] {'1', '0', 'X', '9', '8', '7', '6', '5', '4', '3', '2'};
        //i----表示号码字符从由至左包括校验码在内的位置序号；
        //ai----表示第i位置上的号码字符值；
        //Wi----示第i位置上的加权因子，其数值依据公式intWeight=2（n-1）(mod 11)计算得出。
        var intWeight = new int[] {7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2, 1};
        var craboWeight = 0;
        //从1 到 17 位,18为要生成的验证码
        for (var i = 0; i < 17; i++) {
            craboWeight = craboWeight + Convert.ToUInt16(chrPinCode[i].ToString()) * intWeight[i];
        }

        craboWeight = craboWeight % 11;
        pinCode += chrVerify[craboWeight];
        return pinCode;
    }

    /// <summary>
    /// 生成用户名称
    /// </summary>
    /// <returns></returns>
    public string NameGen() {
        var buffer = new byte[20];
        var random = Random.Shared;
        random.NextBytes(buffer);
        return Convert.ToBase64String(buffer);
    }

    /// <summary>
    /// 生成用户数据
    /// </summary>
    /// <returns>用户实体</returns>
    public User UserDataGen() {
        var res = new User() {
            Id = UserIdGen(),
            Name = NameGen(),
            PassengerId = PassengerIdGen(),
            Password = PasswordGen(),
            PhoneNumber = PhoneNumberGen()
        };
        return res;
    }

    public string PrintUser(User user) {
        var res = "";
        res += $"Id = {user.Id}\n" +
               $"Name = {user.Name}\n" +
               $"PhoneNumber = {user.PhoneNumber}\n" +
               $"PassengerId = {user.PassengerId}\n" +
               $"Password = {user.Password}\n";
        return res;
    }

    [Fact]
    public void Test() {
        const int num = 8;
        var users = new User[num];
        for (var i = 0; i < users.Length; i++) {
            users[i] = UserDataGen();
        }

        foreach (var user in users) {
            _testOutputHelper.WriteLine(PrintUser(user));
        }
    }
}