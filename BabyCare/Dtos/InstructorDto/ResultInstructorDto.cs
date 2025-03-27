namespace BabyCare.Dtos.InstructorDto
{
    public class ResultInstructorDto
    {
        public string InstructorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName => string.Join(" ", FirstName, LastName);
        public string Title { get; set; }

        public string ImageUrl { get; set; }
    }
}
