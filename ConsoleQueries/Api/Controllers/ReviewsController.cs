using ConsoleQueries.Api.DTOs;
using ConsoleQueries.Application.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleQueries.Api.Controllers;

[Authorize]
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
        return await _reviewsService.GetById(id);
    }

    [HttpGet("product/{productId}")]
    public async Task<ActionResult<ReviewDto>> GetByProduct([FromRoute] int productId)
    {
        return Ok(await _reviewsService.GetByProduct(productId));
    }

    [HttpPost]
    public async Task<ActionResult> AddReview([FromBody] ReviewDto review)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        await _reviewsService.AddReview(review);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateReview([FromRoute] int id, [FromBody] ReviewDto review)
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