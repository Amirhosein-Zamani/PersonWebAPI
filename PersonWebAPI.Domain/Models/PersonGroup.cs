#nullable enable

public class PersonGroup
{

    #region peoperties

    public int PersonId { get; set; }
    public int GroupId { get; set; }

    #endregion peoperties 


    #region relations

    public  Person? Person { get; set; }
    public  Group? Group { get; set; }

    #endregion relations 


}

