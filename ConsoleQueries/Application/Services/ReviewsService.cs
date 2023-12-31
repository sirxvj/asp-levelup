using ConsoleQueries.Api.DTOs;
using ConsoleQueries.Application.ServiceInterfaces;
using ConsoleQueries.Data.DataBase;
using ConsoleQueries.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace ConsoleQueries.Application.Services;

public class ReviewsService:IReviewsService
{
    private readonly DataBaseContext _dbc;

    public ReviewsService(DataBaseContext dbc)
    {
        _dbc = dbc;
    }

    public async Task<ReviewDto> GetById(int id)
    {
        return (await _dbc.Reviews
            .Where(r => r.Id == id)
            .FirstOrDefaultAsync())
            .Adapt<ReviewDto>();
    }

    public async Task<IEnumerable<ReviewDto>> GetByProduct(int pId)
    {
        return (await _dbc.Reviews
            .Where(r => r.ProductId == pId)
            .ToListAsync())
            .Adapt<IEnumerable<ReviewDto>>();
    }

    public async Task AddReview(ReviewDto review)
    {
        _dbc.Reviews.Add(review.Adapt<Review>());
        await _dbc.SaveChangesAsync();
    }

    public async Task UpdateReview(int id, ReviewDto review)
    {
        var edited = await _dbc.Reviews.Where(r => r.Id == id).FirstOrDefaultAsync();
        if(edited is not null) _dbc.Entry(edited).CurrentValues.SetValues(new
        {
            review.ProductId,
            review.Comment,
            review.UserId,
            review.Title,
            review.Rating,
            review.Date
        });
    }

    public async Task DeleteReview(int id)
    {
        var review = await _dbc.Reviews
            .Where(r => r.Id == id)
            .FirstOrDefaultAsync();
        if(review is not null)
            _dbc.Reviews.Remove(
                review
            );
        await _dbc.SaveChangesAsync();
    }
}