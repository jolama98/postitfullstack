using System.Reflection;

namespace postitfullstack.Repositories;

public class PicturesRepository
{
    private readonly IDbConnection _db;

    public PicturesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Picture CreatePicture(Picture pictureData)
    {
        string sql = @"
        INSERT INTO pictures (creator_id, album_id, url)
        VALUES (@CreatorId, @AlbumId, @Url);
        SELECT
        pictures.*,
        accounts.*
        FROM pictures
        INNER JOIN accounts ON accounts.id = pictures.creator_id
        WHERE pictures.id = LAST_INSERT_ID()
        ;";
        Picture createdPicture = _db.Query(sql, (Picture picture, Profile account) =>
     {
         picture.Creator = account;
         return picture;
     }, pictureData).SingleOrDefault();
        return pictureData;
    }

    internal List<Picture> GetAllPics()
    {
        string sql = @"
        SELECT pictures.*,
        accounts.*
        FROM pictures
        JOIN accounts ON accounts.id = pictures.creator_id
        GROUP BY (picture.id)
        ;";
        List<Picture> pictures = _db.Query<Picture, Profile, Picture>(sql, JoinCreator).ToList();
        return pictures;
    }

    internal List<Picture> GetPicturesByAlbumId(int albumId)
    {
        string sql = @"
    SELECT
    pictures.*,
    accounts.*
    FROM pictures
    INNER JOIN accounts ON accounts.id = pictures.creator_id
    WHERE pictures.album_id = @albumId;";


        List<Picture> pictures = _db.Query(sql, (Picture picture, Profile profile) =>
      {
          picture.Creator = profile;
          return picture;
      },
      new { albumId }).ToList();
        return pictures;
    }

    private Picture JoinCreator(Picture picture, Profile profile)
    {
        picture.Creator = profile;
        return picture;
    }
}

