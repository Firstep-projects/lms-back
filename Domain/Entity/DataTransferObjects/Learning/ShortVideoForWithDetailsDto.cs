using Entity.Models.Learning;

namespace Entity.DataTransferObjects.Learning;

public class ShortVideoForWithDetailsDto
{
    public long id { get; set; }
    public string videoLinc { get; set; }
    public string title { get; set; }
    public Author author { get; set; }
    public Category category { get; set; }
    public List<long> hashtagId { get; set; }
}
