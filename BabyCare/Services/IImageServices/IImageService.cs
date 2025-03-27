namespace BabyCare.Services.IImageServices
{
    public interface IImageService
    {
        Task<string> SaveImage(IFormFile file);
    }
}
