using CampusConnect.DataAccess.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CampusConnect.Business.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {

        IUserRepository UserRepository { get; }

        int Save();

        new void Dispose();

        TransactionScope StartTransaction();

        void CommitTransaction();

    }
}
