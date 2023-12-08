using ConsoleQueries.Domain.Entities;
using ConsoleQueries.Domain.ServiceInterfaces;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleQueries.Api.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class MediaController:ControllerBase
{
    private readonly IMediaService _mediaService;

    public MediaController(IMediaService mediaService)
    {
        _mediaService = mediaService;
    }

    [HttpGet("product/{pId}")]
    public async Task<ActionResult<IEnumerable<Media>>> GetProductImages([FromRoute] int pId)
    {
        var imgs = await _mediaService.GetImagesByProduct(pId);
        return Ok(imgs);
    }
    
    [HttpPost("product/{pId}")]
    public async Task<IActionResult> PostImageAsync([FromRoute]int pId,[FromQuery(Name = "fileName")]string fileName,[FromQuery(Name="fileType")]string fileType) {
        using var buffer = new System.IO.MemoryStream();
        await this.Request.Body.CopyToAsync(buffer, this.Request.HttpContext.RequestAborted);
        var imageBytes = buffer.ToArray();
        Media image = new Media();
        image.ProductId = pId;
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