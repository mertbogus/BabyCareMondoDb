namespace BabyCare.Dtos.HeroDto
{
    public class UpdateHeroDto
    {
        public string HeroId { get; set; }

        public string HeroTitle { get; set; }

        public string HeroDesc { get; set; }

        public string ImageUrl { get; set; }

        public IFormFile? ImageFile { get; set; }
    }
}
