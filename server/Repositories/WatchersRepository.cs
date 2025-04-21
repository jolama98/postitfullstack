
namespace postitfullstack.Repositories;

public class WatchersRepository
{

    private readonly IDbConnection _db;

    public WatchersRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Watcher CreateWatcher(Watcher watcherData)
    {
        string sql = @"
    INSERT INTO
    watchers( album_id, account_id)
    VALUES ( @AlbumId, @AccountId);

        SELECT
        *
        FROM watchers
        WHERE watchers.id = LAST_INSERT_ID(); ";
        Watcher watcher = _db.Query<Watcher>(sql, watcherData).FirstOrDefault();
        return watcher;

    }
    // WHERE vaultKeep.id = LAST_INSERT_ID();";
}