using System;
using System.Threading.Tasks;

namespace BlogApp.API.Repositories
{
    public interface IRepository : IDisposable
    {
        Task<bool> SaveAsync();
    }
}