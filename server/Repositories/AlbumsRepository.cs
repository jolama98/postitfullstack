

namespace postitfullstack.Repositories;

public class AlbumsRepository
{
    private readonly IDbConnection _db;

    public AlbumsRepository()
    {
    }

    public AlbumsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Album CreateAlbum(Album albumData)
    {

        string sql = @"
    INSERT INTO
    albums(title, description, cover_img, creator_id, category)
    VALUES(@Title, @Description, @CoverImg, @CreatorId, @Category);
    SELECT albums.*,
    accounts.*
    FROM albums
    JOIN accounts ON accounts.id = albums.creator_id
    WHERE albums.id = LAST_INSERT_ID();";

        Album album = _db.Query<Album, Profile, Album>(sql, JoinCreator, albumData).FirstOrDefault();
        return album;
    }

    internal List<Album> GetAllAlbums()
    {
        string sql = @"
    SELECT
    albums.*,
    accounts.*
    FROM albums
    INNER JOIN accounts ON accounts.id = albums.creator_id;";
        List<Album> albums = _db.Query<Album, Profile, Album>(sql, JoinCreator).ToList();
        return albums;
    }

    private Album JoinCreator(Album album, Profile profile)
    {
        album.Creator = profile;
        return album;
    }
}

