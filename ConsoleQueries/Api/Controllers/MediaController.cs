using ConsoleQueries.Domain.Entities;
using ConsoleQueries.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleQueries.Api.Controllers;

[Authorize]
[Route("/api/[controller]")]
[ApiController]
public class MediaController:ControllerBase
{
    private readonly IMediaService _mediaService;

    public MediaController(IMediaService mediaService)
    {
        _mediaService = mediaService;
    }

    [HttpGet("product/{productId}")]
    public async Task<ActionResult<IEnumerable<Media>>> GetProductImages([FromRoute] int productId)
    {
        var imgs = await _mediaService.GetImagesByProduct(productId);
        return Ok(imgs);
    }
    
    [HttpPost("product/{productId}")]
    public async Task<IActionResult> PostImageAsync([FromRoute]int productId,[FromQuery(Name = "fileName")]string fileName,[FromQuery(Name="fileType")]string fileType) {
        using var buffer = new System.IO.MemoryStream();
        await this.Request.Body.CopyToAsync(buffer, this.Request.HttpContext.RequestAborted);
        var imageBytes = buffer.ToArray();
        Media image = new Media();
        image.ProductId = productId;
        image.Bytes = imageBytes;
        image.FileName = fileName;
        image.FileType = fileType;
        await _mediaService.AddImages(image);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task DeleteImage([FromRoute] int id)
    {
        await _mediaService.DeleteImage(id);
    }
}