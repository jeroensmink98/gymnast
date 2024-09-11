namespace Gymnast.Api.DTO;

public class GymnastDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateTime Date { get; set; }
}

public class DeleteGymnastDto
{
    public int Id { get; set; }
}

public class CreateGymnastDto
{
    public string Name { get; set; }
}