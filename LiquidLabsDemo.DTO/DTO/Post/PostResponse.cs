namespace LiquidLabsDemo.DTO.DTO.Post
{
    /// <summary>
    /// Response model sent to front
    /// </summary>
    public class PostResponse
    {
        public int? UserId { get; set; }
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }
    }
}
