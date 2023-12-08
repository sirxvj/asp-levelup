using ConsoleQueries.Models;

namespace ConsoleQueries.Domain.ServiceInterfaces;

public interface IReviewsService
{
    Task<Review> GetById(int id);
    Task<IEnumerable<Review>> GetByProduct(int pId);
    Task AddReview(Review review);
    Task UpdateReview(int id, Review review);

    Task DeleteReview(int id);
}