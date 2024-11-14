using Microsoft.EntityFrameworkCore.Storage;
using PatientManagementApp.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementApp.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork

    {
        private readonly PatientManagementAppDbContext _db;
        private IDbContextTransaction _transaction;
        public UnitOfWork(PatientManagementAppDbContext db)
        {
            _db = db;

            
        }
        public async Task BeginTransAction()
        {
           _transaction = await _db.Database.BeginTransactionAsync();
        }

        public async Task CommitTransAction()
        {
            await _transaction.CommitAsync();
        }

        public void Dispose()
        {
            _db.Dispose();
            
        }

        public async Task RollBackTransAction()
        {
            await _transaction.RollbackAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
           return await _db.SaveChangesAsync();
        }
    }
}
