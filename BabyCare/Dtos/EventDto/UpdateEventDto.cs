namespace BabyCare.Dtos.EventDto
{
    public class UpdateEventDto
    {
        public string EventId { get; set; }
        public string EventTitle { get; set; }
        public string EventDesc { get; set; }
        public DateTime EventDate { get; set; }
        public string EventCity { get; set; }
        public string EventTime { get; set; }
        public string ImageUrl { get; set; }

        public IFormFile? ImageFile { get; set; }
    }
}
