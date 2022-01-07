using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        // asenkronlarda 
        Task CommitAsync();
        // senkronlarda
        void Commit();
    }
}
