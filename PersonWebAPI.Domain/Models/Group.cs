#nullable enable

public class Group
{
    #region properties

    public int GroupId { get; set; }

    public required string GroupName { get; set; }

    public string? Description { get; set; }

    #endregion properties 


    #region relations

    public ICollection<PersonGroup>? PersonGroups{ get; set; }

    #endregion relations 
}

