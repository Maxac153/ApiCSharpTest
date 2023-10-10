public class CreateReq
{
    public CreateReq(string name, string job)
    {
        Name = name;
        Job = job;
    }
    public string Name { get; set; }
    public string Job { get; set; }
}