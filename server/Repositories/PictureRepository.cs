using System.Reflection;

namespace postitfullstack.Repositories;

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
        string sql = @"
        SELECT picture.*,
        accounts.*
        FROM picture
        JOIN accounts ON accounts.id = picture.creatorId
        GROUP BY (picture.id)
        ;";
        List<Picture> pictures = _db.Query<Picture, Profile, Picture>(sql, JoinCreator).ToList();
        return pictures;
    }



    private Picture JoinCreator(Picture picture, Profile profile)
    {
        picture.Creator = profile;
        return picture;
    }
}

