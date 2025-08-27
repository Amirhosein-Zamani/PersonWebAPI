#nullable enable

public class Person
{
    #region properties

    public int PersonID { get; set; }

    public required string Name { get; set; }

    public required string Mobile { get; set; }

    public int? Age { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? Email { get; set; }

    #endregion properties


    #region relations

    public ICollection<PersonGroup>? PersonGroups { get; set; }

    public ICollection<Voucher>? Vouchers{ get; set; }

    #endregion relations 


}
