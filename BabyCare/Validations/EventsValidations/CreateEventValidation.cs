using BabyCare.Dtos.EventDto;
using FluentValidation;

namespace BabyCare.Validations.EventsValidations
{
    public class CreateEventValidation : AbstractValidator<CreateEventDto>
    {
        public CreateEventValidation()
        {
            RuleFor(x => x.ImageFile).NotEmpty().WithMessage("Resim Boş Bırakılamaz.");
            RuleFor(x => x.EventTitle).NotEmpty().WithMessage("Etkinlik Adı Boş Bırakılamaz.").MaximumLength(80)
                .WithMessage("Etkinlik Adı En Fazla 80 karakter olabilir.");
            RuleFor(x => x.EventDesc).NotEmpty().WithMessage("Etkinlik Açıklaması Boş Bırakılamaz.").MaximumLength(250)
                .WithMessage("Etkinlik Adı En Fazla 80 karakter olabilir.");
            RuleFor(x => x.EventCity).NotEmpty().WithMessage("Şehir Bırakılamaz.");
            RuleFor(x => x.EventDate).NotEmpty().WithMessage("Tarih Bırakılamaz.")
                .LessThan(DateTime.Now).WithMessage("Geçmiş Tarih Giremezsiniz.");



        }
    }
}
