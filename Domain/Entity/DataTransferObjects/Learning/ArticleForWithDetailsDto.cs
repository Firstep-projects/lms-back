using Entity.Models.Learning;

namespace Entity.DataTransferObjects.Learning;

public class ArticleForWithDetailsDto
{
    public int id { get; set; }
    public string title { get; set; }
    public string content { get; set; }
    public string image { get; set; }
    public Author author { get; set; }
    public Category category { get; set; }
    public List<int> hashtagIds { get; set; }
}
