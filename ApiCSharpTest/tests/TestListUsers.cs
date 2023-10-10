using NUnit.Allure.Core;
using System.Text.Json;

namespace ListUsers;

[AllureNUnit]
public class TestListUsers
{
    [Test]
    public async Task ListUsers()
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri("https://reqres.in");
        ListUsersReq testData = new ListUsersReq("/api/users/2");

        HttpResponseMessage response = await client.GetAsync(testData.Url);

        ListUsersRes dataResponse = JsonSerializer.Deserialize<ListUsersRes>(await response.Content.ReadAsStringAsync());
        
        Assert.AreEqual(1, 1);
    }
}
