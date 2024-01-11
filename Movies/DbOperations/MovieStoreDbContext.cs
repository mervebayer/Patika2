using System;
using Microsoft.EntityFrameworkCore;
namespace Movies.DbOperations;

public class MovieStoreDbContext : DbContext
{
    public MovieStoreDbContext(DbContextOptions<MovieStoreDbContext> options) : base(options)
    {
        
    }
    public DbSet<Movie> Movies {get; set;}
}