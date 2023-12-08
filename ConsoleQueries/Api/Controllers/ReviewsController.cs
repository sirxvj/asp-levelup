using ConsoleQueries.Api.DTOs;
using ConsoleQueries.Domain.ServiceInterfaces;
using ConsoleQueries.Models;
using Mapster;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleQueries.Api.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class ReviewsController:ControllerBase
{
    private readonly IReviewsService _reviewsService;

    public ReviewsController(IReviewsService reviewsService)
    {
        _reviewsService = reviewsService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReviewDto>> GetById([FromRoute] int id)
    {
        var review = await _reviewsService.GetById(id);
        return review.Adapt<ReviewDto>();
    }

    [HttpGet("product/{pId}")]
    public async Task<ActionResult<ReviewDto>> GetByProduct([FromRoute] int pId)
    {
        var reviews = await _reviewsService.GetByProduct(pId);
        return reviews.Adapt<ReviewDto>();
    }

    [HttpPost]
    public async Task<ActionResult> AddReview([FromBody] Review review)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        await _reviewsService.AddReview(review);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateReview([FromRoute] int id, [FromBody] Review review)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        await _reviewsService.UpdateReview(id, review);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteReview([FromRoute] int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        await _reviewsService.DeleteReview(id);
        return Ok();
    }
    
}