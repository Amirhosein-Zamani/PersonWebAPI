using Mapster;
using PersonWebAPI.Application.DTO.Voucher;
using PersonWebAPI.Application.Services.Intrfaces;
using PersonWebAPI.Domain.Common;
using PersonWebAPI.Domain.Interfaces;

namespace PersonWebAPI.Application.Services.Implementation
{
    public class VoucherService(IVoucherRepository voucherRepository) : IVoucherService
    {
        public async Task<Result<Voucher>> CreateVoucherAsync(CreateVoucherDto CreateVoucherDto)
        {
            var voucher = CreateVoucherDto.Adapt<Voucher>();

            await voucherRepository.AddVoucherAsync(voucher);

            return Result<Voucher>.Success(voucher);

        }

        public async Task<Result<Voucher>> DeleteVoucherAsync(int id)
        {
            var voucher = await voucherRepository.GetVoucherByIdAsync(id);

            if (voucher != null)
            {
                await voucherRepository.DeleteVoucherAsync(voucher);
                return Result<Voucher>.Success(voucher);
            }

            return Result<Voucher>.Failure("کاربری با این آیدی وجود ندارد!");
        }

        public async Task<Result<Voucher>> EditVoucherAsync(int id, EditVoucherDto editVoucherDto)
        {
            var voucher = await voucherRepository.GetVoucherByIdAsync(id);

            if (voucher != null)
            {
                var result = editVoucherDto.Adapt(voucher);

                await voucherRepository.UpdateVoucherAsync(result);

                return Result<Voucher>.Success(result);
            }

            return Result<Voucher>.Failure("ووچر یافت نشد!");

        }

        public async Task<Result<List<VoucherListByGroupIdDto>>> GetVoucherByGroupIdAsync(List<int> groupIds, DateTime? fromDate, DateTime? toDate)
        {
            if (groupIds != null && groupIds.Any())
            {
                var vouchers = await voucherRepository.GetVoucherByGroupIdAsync(groupIds, fromDate, toDate);


                var result = vouchers
                     .Where(v => v.Person != null && v.Person.PersonGroups != null)
                     .SelectMany(v => v.Person.PersonGroups, (voucher, personGroup) => new { voucher, personGroup })
                     .GroupBy(item => item.personGroup.GroupId)
                     .Select(g => new VoucherListByGroupIdDto
                     {
                         GroupId = g.Key,
                         GroupName = g.First().personGroup.Group.GroupName,
                         DebitAmount = g.Sum(v => v.voucher.DebitAmount),
                         CreditAmount = g.Sum(v => v.voucher.CreditAmount),
                         SumAmount = g.Sum(v => v.voucher.DebitAmount + v.voucher.CreditAmount)
                     })
                     .ToList();


                return Result<List<VoucherListByGroupIdDto>>.Success(result);
            }

            return Result<List<VoucherListByGroupIdDto>>.Failure("ورودی ایدی نامعتبره!");


        }

        public async Task<Result<List<VoucherListByPersonIdDto>>> GetVoucherByPersonIdAsync(List<int> personIds, DateTime? fromDate, DateTime? toDate)
        {

            if ((personIds == null || !personIds.Any()))
            {
                return Result<List<VoucherListByPersonIdDto>>.Failure("سندی با این اطلاعات پیدا نشد!");
            }


            var vouchers = await voucherRepository.GetVoucherByPersonIdAsync(personIds, fromDate, toDate);

            if (!vouchers.Any())
                return Result<List<VoucherListByPersonIdDto>>.Failure("هیچ وچری پیدا نشد");


            var result = vouchers
                .GroupBy(v => new { v.PersonId, v.Person.Name })
                .Select(g => new VoucherListByPersonIdDto
                {
                    PersonId = g.Key.PersonId,
                    PersonName = g.Key.Name,
                    DebitAmount = g.Sum(x => x.DebitAmount),
                    CreditAmount = g.Sum(x => x.CreditAmount),
                    SumAmount = g.Sum(x => x.CreditAmount - x.DebitAmount)
                })
                .ToList();

            return Result<List<VoucherListByPersonIdDto>>.Success(result);
        }




    }
}


