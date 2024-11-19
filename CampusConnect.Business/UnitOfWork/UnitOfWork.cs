using CampusConnect.DataAccess.DataModels;
using CampusConnect.DataAccess.IRepositories;
using CampusConnect.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CampusConnect.Business.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork.IUnitOfWork
    {
        private readonly CampusConnectContext _dbContext;
        private TransactionScope _transaction;

        public IUserRepository UserRepository { get; }

        public UnitOfWork(CampusConnectContext context)
        {
            _dbContext = context;

            UserRepository = new UserRepository(context);

        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public TransactionScope StartTransaction()
        {
            _transaction = new TransactionScope();
            return _transaction;
        }

        public void CommitTransaction()
        {
            _transaction.Complete();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
