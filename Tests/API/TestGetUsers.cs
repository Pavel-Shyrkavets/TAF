using TAF.Core;
using TAF.Core.API;

namespace TAF.Tests.API;

[TestClass]
public class TestGetUsers
{
    private const string Endpoint = "https://jsonplaceholder.typicode.com";
    private const int UserCount = 10;
    private const int OkStatusCode = 200;
    private readonly UserClient _usersClient = new(Endpoint);
    private Logger? _logger;

    [TestInitialize]
    public void Initialize()
    {
        _logger = new Logger();
    }

    [TestMethod]
    public async Task VerifyThatUsersCanBeRetrieved()
    {
        var users = await _usersClient.GetUsersAsync();
        var statusCode = await _usersClient.GetUsersStatusCode();
        var numericStatusCode = (int) statusCode;

        _logger?.Information("Number of users retrieved: " + users.Count);
        _logger?.Information("The first user's name: " + users.First().Name);
        _logger?.Information("The 'GET users' response status code: " + numericStatusCode);
        Assert.IsTrue(users.Count.Equals(UserCount));
        Assert.AreEqual(OkStatusCode, numericStatusCode);
    }
}
