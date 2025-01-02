using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using CodeChallenge8_2.Models;
using CodeChallenge8_2.Repository;

namespace MVC_ASSIGNMENT_1.Repository
{
    public class MovieRepository : IMovieRepository
    {
        MoviesContext db;
        public MovieRepository()
        {
            db = new MovieContext();

        }
        public async Task<List<Movie>> GetAllAsync()
        {
            return await db.Contacts.ToListAsync();
        }

        public async Task CreateAsync(Movie movie)
        {
            db.Contacts.Add(movie);
            await db.SaveChangesAsync();
        }
    }
}
