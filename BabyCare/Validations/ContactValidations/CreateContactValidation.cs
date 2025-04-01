using BabyCare.Dtos.ContactDto;
using FluentValidation;

namespace BabyCare.Validations.ContactValidations
{
    public class CreateContactValidation : AbstractValidator<CreateContactDto>
    {
        public CreateContactValidation()
        {
            RuleFor(x => x.Address).NotEmpty().WithMessage("Adres Boş Bırakılamaz.");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail Adresi Boş Bırakılamaz.").EmailAddress().
                WithMessage("Geçerli formatta E-Mail Adresi Girmelisiniz.");
            RuleFor(x => x.SubsectionDesc).NotEmpty().WithMessage("Abone Ol Kısmının Açıklaması Boş Geçilemez.").
                MaximumLength(200).WithMessage("Abone Ol Açıklaması 100 Karakterden Fazla Olamaz.");
            RuleFor(x => x.TwitterUrl).NotEmpty().WithMessage("Twitter Url Boş Bırakılamaz.")
                .Matches(@"^https?:\/\/([a-z0-9]+(\.[a-z0-9]+)*)(:[0-9]{1,5})?(\/[a-z0-9\-\.]+)*\/?$")
                .WithMessage("Geçerli bir URL giriniz.");
            RuleFor(x => x.FacebookUrl).NotEmpty().WithMessage("Facebook Url Boş Bırakılamaz.")
                .Matches(@"^https?:\/\/([a-z0-9]+(\.[a-z0-9]+)*)(:[0-9]{1,5})?(\/[a-z0-9\-\.]+)*\/?$")
                .WithMessage("Geçerli bir URL giriniz.");
            RuleFor(x => x.InstagramUrl).NotEmpty().WithMessage("Instagram Url Boş Bırakılamaz.")
                .Matches(@"^https?:\/\/([a-z0-9]+(\.[a-z0-9]+)*)(:[0-9]{1,5})?(\/[a-z0-9\-\.]+)*\/?$")
                .WithMessage("Geçerli bir URL giriniz.");
            RuleFor(x => x.LinkledinUrl).NotEmpty().WithMessage("Linkledin Url Boş Bırakılamaz.")
                .Matches(@"^https?:\/\/([a-z0-9]+(\.[a-z0-9]+)*)(:[0-9]{1,5})?(\/[a-z0-9\-\.]+)*\/?$")
                .WithMessage("Geçerli bir URL giriniz.");
        }
    }
}
