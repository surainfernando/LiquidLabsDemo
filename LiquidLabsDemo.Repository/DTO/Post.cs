using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquidLabsDemo.Repository.DTO
{
    public class Post
    {
        public int InternalId { get; set; }//THis is the primary key of the table, rest are taken from API response and saved as it is.
        public int? UserId { get; set; }
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }
    }
}
