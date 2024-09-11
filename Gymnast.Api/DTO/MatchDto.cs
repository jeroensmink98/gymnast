namespace Gymnast.Api.DTO;

public class MatchDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Location { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}

public class CreateMatchDto
{
    public string Name { get; set; }
    public string Location { get; set; }
    public DateTime StartTime { get; set; }
}