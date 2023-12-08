using ConsoleQueries.Data.DataBase;
using ConsoleQueries.Domain.Entities;
using ConsoleQueries.Domain.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;

namespace ConsoleQueries.Domain.Services;

public class MediaService:IMediaService
{
    private readonly DataBaseContext _dbc;

    public MediaService(DataBaseContext dbc)
    {
        this._dbc = dbc;
    }

    public async Task<IEnumerable<Media>> GetImagesByProduct(int prodId)
    {
        var img = await _dbc.Media.Where(m => m.ProductId == prodId).ToListAsync();
        return img;
    }

    public async Task AddImages(Media media)
    {
        await _dbc.Media.AddAsync(media);
        await _dbc.SaveChangesAsync();
    }

    public async Task DeleteImage(int id)
    {
        var img = await _dbc.Media.Where(m => m.Id == id).FirstAsync();
        _dbc.Media.Remove(img);
        await _dbc.SaveChangesAsync();
    }
}