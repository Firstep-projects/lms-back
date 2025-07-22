using Entity.Models.Learning;

namespace Entity.DataTransferObjects.Learning;

public class SeminarVideoForWhithDetaileDto
{
    public int id { get; set; }
    public string videoLinc { get; set; }
    public string title { get; set; }
    public Author author { get; set; }
    public Category category { get; set; }
    public List<int> hashtagId { get; set; }
}
