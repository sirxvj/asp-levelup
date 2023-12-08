using ConsoleQueries.Data.DataBase;
using ConsoleQueries.Domain.ServiceInterfaces;
using ConsoleQueries.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleQueries.Domain.Services;

public class ReviewsService:IReviewsService
{
    private readonly DataBaseContext _dbc;

    public ReviewsService(DataBaseContext dbc)
    {
        _dbc = dbc;
    }

    public async Task<Review> GetById(int id)
    {
        var review = await _dbc.Reviews.Where(r => r.Id == id).FirstAsync();
        return review;
    }

    public async Task<IEnumerable<Review>> GetByProduct(int pId)
    {
        var reviews = await _dbc.Reviews.Where(r => r.ProductId == pId).ToListAsync();
        return reviews;
    }

    public async Task AddReview(Review review)
    {
        await _dbc.Reviews.AddAsync(review);
        await _dbc.SaveChangesAsync();
    }

    public async Task UpdateReview(int id, Review review)
    {
        var edited = await _dbc.Reviews.Where(r => r.Id == id).FirstAsync();
        _dbc.Entry(edited).CurrentValues.SetValues(new
        {
            review.ProductId,
            review.Comment,
            review.UserId,
            review.Titile,
            review.Rating,
            review.Date
        });
    }

    public async Task DeleteReview(int id)
    {
        var deleted = await _dbc.Reviews.Where(r => r.Id == id).FirstAsync();
        _dbc.Reviews.Remove(deleted);
        await _dbc.SaveChangesAsync();
    }
}