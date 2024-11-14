using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementApp.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync();  //Kaç kayda etki ettiğini geriye döner.O yüzden int olarak belirlenmeli.

        Task BeginTransAction();
        Task CommitTransAction();
        Task RollBackTransAction();
    }
}
