using System.Collections.Generic;
using System.Threading.Tasks;
using Desafio.Model;

namespace Desafio.Repostitory
{
    public interface IRepository
    {
    Task<bool> SaveChangeAsync();

        void AddRows(IEnumerable<User> user);

        Task<IEnumerable<User>>FilterBySuite(List<User> user);

        Task<List<User>> GetDados();




    }
}