using FluentValidation;
using Microsoft.Extensions.Options;
using PersonWebAPI.Application.DTO.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonWebAPI.Application.Validator
{
    public class PersonCreateDtoValidator : AbstractValidator<PersonCreateDto>
    {
        public PersonCreateDtoValidator()
        {

            RuleFor(p => p.Name)
               .NotEmpty()
               .WithMessage("نام الزامی است.")

               .NotNull()
               .WithMessage("نام الزامی است.")

               .MaximumLength(100)
               .WithMessage("نام نباید بیشتر از 100 کاراکتر باشد.");


            RuleFor(p => p.Mobile)
                   .NotEmpty()
                   .WithMessage("شماره موبایل الزامی است.")

                   .Length(11)
                   .WithMessage("شماره موبایل باید دقیقاً 11 رقم باشد.")


                   .Matches(@"^09/d{9}$") 
                   .WithMessage("شماره موبایل باید با 09 شروع شده و 11 رقم باشد.");


            RuleFor(p => p.GroupIds)
                .NotNull()
                .WithMessage("انتخاب حداقل یک گروه الزامی است.");
               
        }
    }
}
