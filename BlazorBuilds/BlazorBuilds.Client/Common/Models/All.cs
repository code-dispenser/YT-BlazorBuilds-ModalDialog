namespace BlazorBuilds.Client.Common.Models;

public record class SomePersonData
{
    public required string FirstName { get; set; } 
    public required string Surname   { get; set; } 
    public required int    Age       { get; set; } 
    public required string Country   { get; set; }
}


public record SomePersonView(string FullName, string Spouse);