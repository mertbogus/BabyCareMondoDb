using AutoMapper;
using BabyCare.DataAccess.Entities;
using BabyCare.Dtos.InstructorDto;

namespace BabyCare.Mappings
{
    public class InstructorMapping : Profile
    {
        public InstructorMapping()
        {

            CreateMap<ResultInstructorDto, Instructor>().ReverseMap();
            CreateMap<UpdateInstructorDto, Instructor>().ReverseMap();
            CreateMap<CreateInstructorDto, Instructor>().ReverseMap();


        }

    }
}
