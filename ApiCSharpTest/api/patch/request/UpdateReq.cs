public class UpdateReq
{
    public UpdateReq(string name, string job)
    {
        Name = name;
        Job = job;
    }

    public string Name { get; set; }
    public string Job { get; set; }
}