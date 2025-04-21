namespace postitfullstack.Models;
public class Picture : RepoItem<int>
{
    public string CreatorId { get; set; }
    public int AlbumId { get; set; }
    public string ImgUrl { get; set; }
    public Profile Creator { get; set; }

}


