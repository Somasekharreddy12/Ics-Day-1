using CodeChallenge8_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge8_2.Repository
{
    public interface IContactRepository
    {
        Task<List<Movie>> GetAllAsync();
        Task CreateAsync(MovieRepository contact);
        Task EditAsync( Movie ID);

    }
}
