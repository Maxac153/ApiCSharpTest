using NUnit.Allure.Core;

namespace DeleteUser;

[AllureNUnit]
public class TestDeleteUser
{
    [Test]
    public async Task DeleteUser()
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri("https://reqres.in"); 
        DeleteUserReq testData = new DeleteUserReq("/api/users/2");

        HttpResponseMessage response = await client.DeleteAsync(testData.Url);
        
        Assert.AreEqual(204, (int)response.StatusCode);
    }
}