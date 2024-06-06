using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class UrlManagement
    {
        public int Id { get; set; }
        public string OriginalUrl { get; set; }
        public string ShortUrl { get; set; }
        public int Clicks { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string UserId { get; set; }
        public AppUser User { get; set; }
    }
}
