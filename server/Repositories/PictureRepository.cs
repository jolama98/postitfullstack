using System.Reflection;

namespace postitfullstack.Repositories;
public class AlbumRepository
{
    private readonly IDbConnection _db;

    public AlbumRepository()
    {
    }

    public AlbumRepository(IDbConnection db)
    {
        _db = db;
    }
}

public class PictureRepository
{
    private readonly IDbConnection _db;

    public PictureRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Picture CreatePicture(Picture pictureData)
    {
        string sql = @"
        INSERT INTO picture (creatorId, albumId, url)
        VALUES (@CreatorId, @AlbumId, @Url);
        SELECT LAST_INSERT_ID();";
        pictureData.Id = _db.ExecuteScalar<int>(sql, pictureData);
        return pictureData;
    }

    internal List<Picture> GetAllPics()
    {
        string sql = "SELECT * FROM picture";
        return _db.Query<Picture>(sql).ToList();
    }
}

