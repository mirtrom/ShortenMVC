using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUrlService: ICrud<UrlModel>
    {
        public Task<IEnumerable<UrlModel>> GetByUserIdAsync(string shortUrl);
        public Task<UrlModel> GetByShortUrlAsync(string shortUrl);
    }
}
