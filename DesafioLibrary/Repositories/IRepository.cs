using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioLibary.Model;

namespace DesafioLibrary.Repositories
{
    public interface IRepository
    {
    Task<bool> SaveChangeAsync();

        void AddRows(IEnumerable<User> user);

        Task<IEnumerable<User>>FilterBySuite(List<User> user);

        Task<List<User>> GetDados();




    }
}