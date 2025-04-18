namespace postitfullstack.Models;

public class Picture : RepoItem<int>
{
    public string CreatorId { get; set; }
    public string AlbumId { get; set; }
    public string Url { get; set; }

}


