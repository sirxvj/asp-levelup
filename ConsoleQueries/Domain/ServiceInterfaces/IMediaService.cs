using ConsoleQueries.Domain.Entities;

namespace ConsoleQueries.Domain.ServiceInterfaces;

public interface IMediaService
{
    Task<IEnumerable<Media>> GetImagesByProduct(int prodId);
    Task AddImages(Media media);
    Task DeleteImage(int id);
}