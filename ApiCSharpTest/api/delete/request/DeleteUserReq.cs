using System.ComponentModel.DataAnnotations;

public class DeleteUserReq
{
    public DeleteUserReq(string url) { Url = url; }
    public string Url { get; set; }
}