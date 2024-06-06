using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IUrlManagementRepository UrlManagementRepository { get; set; }
        Task SaveAsync();
    }
}
