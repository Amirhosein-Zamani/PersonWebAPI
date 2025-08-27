namespace PersonWebAPI.Domain.Interfaces
{
    public interface IVoucherRepository
    {
        Task<List<Voucher>> GetVoucherByPersonIdAsync(List<int> personIds, DateTime? fromDate, DateTime? toDate);

        Task<List<Voucher>> GetVoucherByGroupIdAsync(List<int> groupIds, DateTime? fromDate, DateTime? toDate);

        Task AddVoucherAsync(Voucher voucher);

        Task UpdateVoucherAsync(Voucher voucher);

        Task<Voucher?> GetVoucherByIdAsync(int id);

        Task DeleteVoucherAsync(Voucher voucher);

    }
}
