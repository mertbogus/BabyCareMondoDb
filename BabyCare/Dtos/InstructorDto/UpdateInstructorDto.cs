namespace BabyCare.Dtos.InstructorDto
{
    public class UpdateInstructorDto
    {
        public string InstructorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public IFormFile? ImageFile { get; set; }
    }
}
