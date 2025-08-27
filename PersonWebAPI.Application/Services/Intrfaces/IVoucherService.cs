using PersonWebAPI.Application.DTO.Voucher;
using PersonWebAPI.Domain.Common;

namespace PersonWebAPI.Application.Services.Intrfaces
{
    public interface IVoucherService
    {
        Task<Result<List<VoucherListByPersonIdDto>>> GetVoucherByPersonIdAsync(List<int> personIds, DateTime? fromDate, DateTime? toDate);

        Task<Result<List<VoucherListByGroupIdDto>>> GetVoucherByGroupIdAsync(List<int> groupIds, DateTime? fromDate, DateTime? toDate);

        Task<Result<Voucher>> CreateVoucherAsync(CreateVoucherDto CreateVoucherDto);

        Task<Result<Voucher>> EditVoucherAsync(int id, EditVoucherDto editVoucherDto);

        Task<Result<Voucher>> DeleteVoucherAsync(int id);
    }



}
