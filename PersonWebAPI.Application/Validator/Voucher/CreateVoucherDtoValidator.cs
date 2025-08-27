using FluentValidation;
using PersonWebAPI.Application.DTO.Voucher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonWebAPI.Application.Validator.Voucher
{
    public class CreateVoucherDtoValidator : AbstractValidator<CreateVoucherDto>
    {

        public CreateVoucherDtoValidator()
        {


            RuleFor(v => v.PersonId)
                .NotNull()
                .NotEmpty()
                .WithMessage("وارد کردن آیدی کاربر الزامیست")
                .GreaterThan(0)
                .WithMessage("شناسه شخص معتبر نیست.");


            RuleFor(v => v.VoucherName)
                .NotEmpty()
                .WithMessage("نام ووچر الزامی است.")
                .MaximumLength(200)
                .WithMessage("نام ووچر نباید بیشتر از 200 کاراکتر باشد.");


            RuleFor(v => v.VoucherType)
                .NotNull()
                .NotEmpty()
                .WithMessage("وارد کردن نوع ووچر الزامیست")
                .IsInEnum()
                .WithMessage("نوع ووچر معتبر نیست.");


            RuleFor(v => v.DebitAmount)
                .NotNull()
                .NotEmpty()
                .WithMessage("وارد کردن مبلغ بدهکاری الزامیست")
                .GreaterThanOrEqualTo(0)
                .WithMessage("مبلغ بدهکار نمی‌تواند منفی باشد.");


            RuleFor(v => v.CreditAmount)
                .NotNull()
                .NotEmpty()
                .WithMessage("وارد کردن مبلغ بستانکاری الزامیست")
                .GreaterThanOrEqualTo(0)
                .WithMessage("مبلغ بستانکار نمی‌تواند منفی باشد.");


            RuleFor(v => v)
               .Must(v => v.DebitAmount > 0 || v.CreditAmount > 0)
               .WithMessage("حداقل یکی از مبالغ بدهکار یا بستانکار باید بیشتر از صفر باشد.");
        }

    }
}
