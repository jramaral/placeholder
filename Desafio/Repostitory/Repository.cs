using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Desafio.Data;
using Desafio.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Desafio.Repostitory
{
    public class Repository: IRepository
    {
        public readonly DataContext _Context;
        public Repository(DataContext context)
        {
            _Context = context;
            _Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
       
        public async Task<bool> SaveChangeAsync()
        {
            return await _Context.SaveChangesAsync() > 0;
        }

        public void AddRows(IEnumerable<User> user)
        {
            _Context.AddRange(user);
        }

        public async Task<IEnumerable<User>> FilterBySuite(List<User> user)
        {
            var query =  user.Where(a => a.Address.Suite.ToLower().Contains("suite")).ToList();
            return query;

        }

        public async Task<List<User>> GetDados()
        {
            List<User> users = new List<User>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/users"))
                {
                    string apiResp = await response.Content.ReadAsStringAsync();
                    users = JsonConvert.DeserializeObject<List<User>>(apiResp);
                }
                
            }

            return users;
        }
    }
}