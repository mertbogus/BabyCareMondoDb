namespace BabyCare.Dtos.TestimonialDto
{
    public class CreateTestimonialDto
    {
        public string Description { get; set; }
        public string CommenterFullName { get; set; }
        public string CommenterImage { get; set; }

        public IFormFile? ImageFile { get; set; }
        public int Rating { get; set; }
    }
}
