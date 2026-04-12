using System;
using System.Collections.Generic;
using System.Text;
using UmrahBookingSystem.Application.Interfaces.Repositories;
using UmrahBookingSystem.Infrastructure.Persistence.Context;

namespace UmrahBookingSystem.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
