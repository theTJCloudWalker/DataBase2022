using Xunit;
using Xunit.Abstractions;

namespace AirlineTicketing.Test.TestDataGenerator;

public class OrderIdGenerate {
    private readonly ITestOutputHelper _testOutputHelper;

    public OrderIdGenerate(ITestOutputHelper testOutputHelper) {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Gen() {
        var time = DateTime.Now;
        var timeString = time.ToString("yyyyMMddhhmmss");
        _testOutputHelper.WriteLine(timeString);
    }
}