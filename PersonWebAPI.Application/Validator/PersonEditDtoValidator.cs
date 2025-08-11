using FluentValidation;
using PersonWebAPI.Application.DTO.Person;
using PersonWebAPI.Application.Services.Implementation;
using PersonWebAPI.Application.Services.Intrfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonWebAPI.Application.Validator
{
    public class PersonEditDtoValidator : AbstractValidator<PersonEditDto>
    {
        private readonly IGroupService _groupService;

        public PersonEditDtoValidator(IGroupService groupService)
        {
            _groupService = groupService;

            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("نام الزامی است.")

                .MaximumLength(100)
                .WithMessage("نام نباید بیشتر از 100 کاراکتر باشد.");


            RuleFor(p => p.Mobile)
               .NotEmpty()
               .WithMessage("شماره موبایل الزامی است.")

               .Length(11)
               .WithMessage("شماره موبایل باید دقیقاً 11 رقم باشد.")

               .Matches(@"^09\d{9}$")
               .WithMessage("شماره موبایل باید با 09 شروع شده و 11 رقم باشد.");


            RuleFor(p => p.Age)
               .GreaterThanOrEqualTo(18)
               .WithMessage("سن باید حداقل 18 سال باشد.")

               .LessThanOrEqualTo(100)
               .WithMessage("سن نمی‌تواند بیشتر از 100 سال باشد.");



            RuleFor(p => p.Address)
                .MaximumLength(200)
                .WithMessage("آدرس نمیتواند بیشتر از 200 کاراکتر باشه.");



            RuleFor(p => p.City)
                .MaximumLength(50)
                .WithMessage("نام شهر نمی‌تواند بیشتر از 50 کاراکتر باشد.");



            RuleFor(p => p.Id)
                .MustAsync(async (groupId, CancellationToken) =>
                {
                    return await groupService.ExistGroupByIdAsync(groupId, CancellationToken);

                })
                .WithMessage("گروه انتخاب‌شده وجود ندارد");



            RuleFor(x => x.GroupIds)
               .NotNull().WithMessage("حداقل یک گروه باید انتخاب شود.");



        }
    }
}
