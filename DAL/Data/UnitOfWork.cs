using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        public IUrlManagementRepository UrlManagementRepository { get; set; }
        public UnitOfWork(Context context)
        {
            _context = context;
            UrlManagementRepository = new UrlManagementRepository(_context);
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
