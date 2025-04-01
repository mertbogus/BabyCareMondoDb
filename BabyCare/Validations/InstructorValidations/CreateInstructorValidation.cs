using BabyCare.Dtos.InstructorDto;
using FluentValidation;

namespace BabyCare.Validations.InstructorValidations
{
    public class CreateInstructorValidation : AbstractValidator<CreateInstructorDto>
    {
        public CreateInstructorValidation()
        {
            RuleFor(x => x.ImageFile).NotEmpty().WithMessage("Resim Boş Bırakılamaz.");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Eğitmen Adı Boş Bırakılamaz.").
                MaximumLength(35).WithMessage("Eğitmen Adı 35 Karakterden Fazla Olamaz.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Eğitmen Soyadı Boş Bırakılamaz.").
                 MaximumLength(35).WithMessage("Eğitmen Soyadı 35 Karakterden Fazla Olamaz.");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Eğitmen Ünvanı Boş Bırakılamaz.").
                MaximumLength(50).WithMessage("Eğitmen Adı 50 Karakterden Fazla Olamaz.");
        }
    }
}
