namespace LiquidLabsDemo.DTO.DTO.Post
{
    /// <summary>
    /// Used to Get Post data from 3rd party APIS
    /// </summary>
    public class GetPostResponse
    {
        public int userId { get; set; }
        public int Id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
    }
}
