#nullable disable

using PersonWebAPI.Domain.Enums;

public class Voucher
{

    #region properties


    public int VoucherId { get; set; }

    public int PersonId { get; set; }

    public required string VoucherName { get; set; }

    public required VoucherType VoucherType { get; set; }

    public required decimal DebitAmount { get; set; }

    public required decimal CreditAmount { get; set; }

    public DateTime IssuanceDate { get; set; }

    public string? Description { get; set; }


    #endregion properties



    #region relation

    public Person Person { get; set; }

    #endregion relation

}
