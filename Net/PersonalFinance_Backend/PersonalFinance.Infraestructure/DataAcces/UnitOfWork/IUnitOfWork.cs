using System;

namespace PersonalFinance.Infraestructure.DataAcces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        new void Dispose();
        int Save();
        void Rollback();
    }
}
