namespace PostgresEnumError.Models;

public class Person
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required MarriageStatus MarriageStatus { get; set; }
}
