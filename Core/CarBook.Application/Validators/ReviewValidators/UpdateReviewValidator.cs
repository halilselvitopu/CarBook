using CarBook.Application.Features.Mediator.Commands.ReviewCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Validators.ReviewValidators
{
    public class UpdateReviewValidator : AbstractValidator<UpdateReviewCommand>
    {
        public UpdateReviewValidator()
        {
            RuleFor(x => x.CustomerFirstName).NotEmpty().WithMessage("Lütfen müşteri adını boş geçmeyiniz.");
            RuleFor(x => x.CustomerFirstName).MinimumLength(2).WithMessage("Müşteri adı minimum 2 karakter olmalıdır.");
            RuleFor(x => x.CustomerLastName).MinimumLength(2).WithMessage("Müşteri soyadı minimum 2 karakter olmalıdır.");
            RuleFor(x => x.RatingValue).NotEmpty().WithMessage("Lütfen puan değerini boş geçmeyiniz.");
            RuleFor(x => x.Comment).NotEmpty().WithMessage("Lütfen yorumu boş geçmeyiniz.");
            RuleFor(x => x.Comment).MinimumLength(30).WithMessage("Lütfen en az 30 karakterlik veri girişi yapınız.");
            RuleFor(x => x.Comment).MaximumLength(500).WithMessage("Lütfen en fazla 500 karakterlik veri girişi yapınız.");
        }
    }
}
