using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertiseService.Infrastructure.Data
{
    public interface IUnitOfWork

    {

        Task<int> SaveChangesAsync(CancellationToken ct = default);

    }

    public class UnitOfWork : IUnitOfWork

    {

        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)

        {

            _context = context;

        }

        public async Task<int> SaveChangesAsync(CancellationToken ct = default)

        {

            return await _context.SaveChangesAsync(ct);

        }

    }
}
