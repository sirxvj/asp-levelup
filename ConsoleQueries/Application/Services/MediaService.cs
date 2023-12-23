using ConsoleQueries.Data.DataBase;
using ConsoleQueries.Domain.Entities;
using ConsoleQueries.Domain.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;

namespace ConsoleQueries.Application.Services;

public class MediaService:IMediaService
{
    private readonly DataBaseContext _dbc;

    public MediaService(DataBaseContext dbc)
    {
        this._dbc = dbc;
    }

    public async Task<IEnumerable<Media>> GetImagesByProduct(int prodId)
    {
        return await _dbc.Media.Where(m => m.ProductId == prodId).ToListAsync();
    }

    public async Task AddImages(Media media)
    {
        _dbc.Media.Add(media);
        await _dbc.SaveChangesAsync();
    }

    public async Task DeleteImage(int id)
    {
        _dbc.Media.Remove(await _dbc.Media.Where(m => m.Id == id).FirstAsync());
        await _dbc.SaveChangesAsync();
    }
}