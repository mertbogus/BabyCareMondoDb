namespace BabyCare.Dtos.InstructorDto
{
    public class CreateInstructorDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Title { get; set; }

        public string? TwitterUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public string? LinkledinUrl { get; set; }

        public string? ImageUrl { get; set; }

        public IFormFile? ImageFile { get; set; }
    }
}
