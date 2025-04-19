namespace postitfullstack.Models;
public class Picture : RepoItem<int>
{
    public string CreatorId { get; set; }
    public int AlbumId { get; set; }
    public string Url { get; set; }
    public Profile Creator { get; set; }

}


