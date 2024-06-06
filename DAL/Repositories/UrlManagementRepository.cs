using DAL.Data;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
	public class UrlManagementRepository : Repository<UrlManagement>, IUrlManagementRepository
    {
        public UrlManagementRepository(Context context) : base(context)
        {
        }

        public async Task<UrlManagement> GetByShortUrlAsync(string shortUrl)
        {
            return await dbSet.FirstOrDefaultAsync(x => x.ShortUrl == shortUrl);
        }

        public async Task<IEnumerable<UrlManagement>> GetByUserIdAsync(string userId)
		{
			return await dbSet.Where(x => x.UserId == userId).ToListAsync();
		}
	}
}
