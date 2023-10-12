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
        
        Assert.AreEqual(dataResponse.data.avatar, "https://reqres.in/img/faces/2-image.jpg");
        Assert.AreEqual(dataResponse.data.email, "janet.weaver@reqres.in");
        Assert.AreEqual(dataResponse.data.first_name, "Janet");
        Assert.AreEqual(dataResponse.data.id, 2);
        Assert.AreEqual(dataResponse.data.last_name, "Weaver");
        Assert.AreEqual(dataResponse.support.text, "To keep ReqRes free, contributions towards server costs are appreciated!");
        Assert.AreEqual(dataResponse.support.url, "https://reqres.in/#support-heading");
    }
}
