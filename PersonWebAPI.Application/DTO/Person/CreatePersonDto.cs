namespace PersonWebAPI.Application.DTO.Person;

#nullable enable

public class CreatePersonDto
{
    public string? Name { get; set; }

    public string? Mobile { get; set; }

    public List<int>? GroupIds { get; set; }
}

