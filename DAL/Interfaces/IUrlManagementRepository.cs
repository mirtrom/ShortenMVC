using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUrlManagementRepository: IRepository<UrlManagement>
    {
        public Task<IEnumerable<UrlManagement>> GetByUserIdAsync(string userId);

        public Task<UrlManagement> GetByShortUrlAsync(string shortUrl);
    }
}
