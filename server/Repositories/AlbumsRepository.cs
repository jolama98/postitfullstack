


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
    
    SELECT
    albums.*,
    accounts.*
    FROM albums
    INNER JOIN accounts ON accounts.id = albums.creator_id
    WHERE albums.id = LAST_INSERT_ID();";

        Album createdAlbum = _db.Query(sql, (Album album, Profile account) =>
        {
            album.Creator = account;
            return album;
        }, albumData).SingleOrDefault();
        return createdAlbum;
    }

    internal void ArchiveAlbum(Album album)
    {
        string sql = "UPDATE albums SET Archived = @Archived WHERE id = @Id LIMIT 1;";

        int rowsAffected = _db.Execute(sql, album);
        switch (rowsAffected)
        {
            case 1:
                return;
            case 0:
                throw new Exception("UPDATE WAS NOT SUCCESSFUL");
            default:
                throw new Exception("UPDATE WAS TOO SUCCESSFUL");
        }
    }

    internal Album GetAlbumById(int albumId)
    {
        string sql = @"
        SELECT
        albums.*,
        accounts.*
        FROM albums
        INNER JOIN accounts ON accounts.id = albums.creator_id
        WHERE albums.id = @albumId; ";



        Album album = _db.Query<Album, Profile, Album>(sql, JoinCreator, new { albumId }).FirstOrDefault();
        if (album == null)
        {
            throw new Exception("Invalid Album Id");
        }
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

