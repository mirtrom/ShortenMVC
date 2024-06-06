using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class UrlModel
    {
        public int Id { get; set; }
        public string OriginalUrl { get; set; }
        public string ShortUrl { get; set; }
        public int Clicks { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserId { get; set; }
        public UrlModel(string longUrl, string userId)
        {
            OriginalUrl = longUrl;
            Clicks = 0;
            CreatedAt = DateTime.Now;
            UserId = userId;
            ShortUrl = Utilities.ShortenLinkGenerator.ShortenLink(longUrl);
        }
        public UrlModel()
        {
            
        }
        public void IncrementClicks()
        {
            Clicks++;
        }
    }
}
