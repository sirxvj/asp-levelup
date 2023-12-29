using ConsoleQueries.Api.DTOs;
using ConsoleQueries.Models;

namespace ConsoleQueries.Application.ServiceInterfaces;

public interface IReviewsService
{
    Task<ReviewDto> GetById(int id);
    Task<IEnumerable<ReviewDto>> GetByProduct(int pId);
    Task AddReview(ReviewDto review);
    Task UpdateReview(int id, ReviewDto review);
    Task DeleteReview(int id);
}