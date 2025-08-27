using PersonWebAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonWebAPI.Application.DTO.Voucher
{
    public class CreateVoucherDto
    {
        public int PersonId { get; set; }

        public required string VoucherName { get; set; }

        public required VoucherType VoucherType { get; set; }

        public required decimal DebitAmount { get; set; }

        public required decimal CreditAmount { get; set; }

        public DateTime IssuanceDate { get; set; }

        public string? Description { get; set; }

    }
}
