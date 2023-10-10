using NUnit.Allure.Core;
using System.Text;
using System.Text.Json;

namespace Update;

[AllureNUnit]
public class TestUpdate
{
    [Test]
    public async Task Update()
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri("https://reqres.in");
        var testData = new UpdateReq("morpheus", "zion resident");

        var content = new StringContent(JsonSerializer.Serialize<UpdateReq>(testData), Encoding.UTF8, "application/json");
    
        var response = await client.PatchAsync("/api/users/2", content);

        var dataResponse = JsonSerializer.Deserialize<UpdateRes>(await response.Content.ReadAsStringAsync());
    }
}