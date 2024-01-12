using System.Globalization;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movies.DbOperations;
using Movies.Dtos;
using WebApi.MovieOperations.CreateMovie;
using WebApi.MovieOperations.DeleteMovie;
using WebApi.MovieOperations.GetById;
using WebApi.MovieOperations.GetMovies;
using WebApi.MovieOperations.UpdateMovies;
using static WebApi.MovieOperations.CreateMovie.CreateMovieCommand;

namespace Movies.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController : ControllerBase
{
    private readonly MovieStoreDbContext context;
    private readonly IMapper mapper;

    public MoviesController(MovieStoreDbContext context,IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    [HttpGet]
    public IActionResult Get()
    {
        GetMoviesQuery query = new(context);
        var result = query.Handle();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        MovieDetailViewModel result;
        try{
            GetByIdQuery query = new(context)
            {
                MovieId = id
            };
            result =query.Handle();
        }
        catch(Exception ex){
            return BadRequest(ex.Message);
        }
        return Ok(result);    
    }

    [HttpGet("GetByIdQuery")]
    public IActionResult GetByIdQuery([FromQuery] int id)
    {
        var movie = context.Movies.FirstOrDefault(x=>x.Id == id);
        if(movie == null)
        {
            return NotFound();
        }
        return Ok(movie);
    }

    [HttpGet("GetByParameter")]
    public IActionResult GetByParameter([FromQuery] string? Title, [FromQuery] string? Language)
    {
        var movies = context.Movies.AsQueryable();
        if(!string.IsNullOrEmpty(Title)){
            movies = movies.Where(x => x.Title.Contains(Title, StringComparison.OrdinalIgnoreCase));
        }
        if(!string.IsNullOrEmpty(Language)){
            movies = movies.Where(x => x.Language.Contains(Language, StringComparison.OrdinalIgnoreCase));
        }
        return Ok( movies.ToList<Movie>());
    }

    [HttpPost]
    public IActionResult AddMovie([FromBody] CreateMovieModel movie){
        CreateMovieCommand command = new(context,mapper)
        {
            Model = movie
        };
        command.Handle();
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieModel movie){
        UpdateMovieCommand command = new(context)
        {
            MovieId = id,
            Model = movie
        };
        command.Handle();
                return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMovie(int id){
        DeleteMovieCommand command = new(context)
        {
            MovieId = id
        };
        command.Handle();
                return Ok();
    }

    [HttpGet]
    [Route("SortBy")]
    public IActionResult SortBy([FromQuery] string sorting)
    {
        var movie = context.Movies.AsQueryable();

        if (!string.IsNullOrEmpty(sorting) && sorting.ToUpper(CultureInfo.InvariantCulture)== "TITLE")
        {
            movie = movie.OrderBy(x => x.Title);
        }
        
        else if (!string.IsNullOrEmpty(sorting) && sorting.ToUpper(CultureInfo.InvariantCulture) == "LANGUAGE")
        {
            movie = movie.OrderBy(x => x.Language);
        }

        else{
            return BadRequest();
        }
        context.SaveChanges();
        return Ok(movie.ToList());
    }
    
}

