using Microsoft.EntityFrameworkCore;
using PersonWebAPI.Domain.Interfaces;
using PersonWebAPI.Infra.Data.Context;

namespace PersonWebAPI.Infra.Data.Repository
{
    public class VoucherRepository(PersonWebAPIContext context) : IVoucherRepository
    {
        public async Task AddVoucherAsync(Voucher voucher)
        {
            context.Vouchers.Add(voucher);
            await context.SaveChangesAsync();
        }

        public async Task DeleteVoucherAsync(Voucher voucher)
        {
            context.Vouchers.Remove(voucher);
            await context.SaveChangesAsync();
        }

        public async Task<List<Voucher>> GetVoucherByGroupIdAsync(List<int> groupIds, DateTime? fromDate, DateTime? toDate)
        {
            var query = context.Vouchers
            .Include(v => v.Person)
            .ThenInclude(p => p.PersonGroups)
            .ThenInclude(pg => pg.Group)
            .Where(v => v.Person != null && v.Person.PersonGroups.Any(pg => groupIds.Contains(pg.GroupId)));


            if (fromDate.HasValue)
            {
                query = query.Where(v => v.IssuanceDate >= fromDate.Value);
            }
            if (toDate.HasValue)
            {
                query = query.Where(v => v.IssuanceDate <= toDate.Value);
            }

            return await query.ToListAsync();

        }

        public async Task<Voucher?> GetVoucherByIdAsync(int id)
        {
            return await context.Vouchers.FirstOrDefaultAsync(v => v.VoucherId == id);
        }

        public async Task<List<Voucher>> GetVoucherByPersonIdAsync(List<int> personIds, DateTime? fromDate, DateTime? toDate)
        {

            return await context.Vouchers
                  .Include(v => v.Person)
                  .Where(p => personIds.Contains(p.PersonId))
                  .Where(p => !fromDate.HasValue || p.IssuanceDate >= fromDate)
                  .Where(p => !toDate.HasValue || p.IssuanceDate <= toDate)
                  .ToListAsync();

        }

        public Task UpdateVoucherAsync(Voucher voucher)
        {
            context.Vouchers.Update(voucher);
            return context.SaveChangesAsync();
        }
    }
}
