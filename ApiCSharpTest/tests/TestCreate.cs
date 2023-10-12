using NUnit.Allure.Core;
using System.Text;
using System.Text.Json;

namespace Create;

[AllureNUnit]
public class TestCreate
{
    [Test]
    public async Task Create()
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri("https://reqres.in");
        var testData = new CreateReq("morpheus", "leader");

        var content = new StringContent(JsonSerializer.Serialize<CreateReq>(testData), Encoding.UTF8, "application/json");

        var response = await client.PostAsync("/api/users", content);

        var dataResponse = JsonSerializer.Deserialize<CreateRes>(await response.Content.ReadAsStringAsync());

        Assert.IsTrue(dataResponse.createdAt.Contains(DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss")));
    }
}