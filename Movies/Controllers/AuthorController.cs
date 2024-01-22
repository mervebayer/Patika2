using System.Globalization;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movies.DbOperations;
using Movies.Dtos;
using FluentValidation;
using FluentValidation.Results;
using Movies.Entities;
using Movies.Application.AuthorOperations.Queries.GetAuthors;
using Movies.Application.AuthorOperations.Queries.GetAuthorDetail;
using static Movies.Application.AuthorOperations.Command.CreateAuthor.CreateAuthorCommand;
using Movies.Application.AuthorOperations.Command.CreateAuthor;
using Movies.Application.AuthorOperations.Command.UpdateAuthor;
using Movies.Application.GenreOperations.Command.UpdateGenre;
using Movies.Application.AuthorOperations.Command.DeleteAuthor;


namespace Movies.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorController : ControllerBase
{
    private readonly MovieStoreDbContext context;
    private readonly IMapper mapper;

    public AuthorController(MovieStoreDbContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAuthors()
    {
        GetAuthorsQuery query = new(context, mapper);
        var result = query.Handle();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetAuthorDetail(int id)
    {
        AuthorDetailViewModel result;
        try
        {
            GetAuthorDetailQuery query = new(context, mapper)
            {
                AuthorId = id
            };
            GetAuthorDetailQueryValidator validator = new();
            validator.ValidateAndThrow(query);
            result = query.Handle();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return Ok(result);
    }


    [HttpPost]
    public IActionResult AddAuthor([FromBody] CreateAuthorModel author)
    {
        CreateAuthorCommand command = new(context, mapper);
        try
        {
            command.Model = author;
            CreateAuthorCommandValidator validator = new();
            validator.ValidateAndThrow(command);
            command.Handle();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
   
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAuthor(int id, [FromBody] UpdateAuthorModel author)
    {
        try
        {
            UpdateAuthorCommand command = new(context);
            command.AuthorId = id;
            command.Model = author;
            UpdateAuthorCommandValidator validator = new();
            validator.ValidateAndThrow(command);
            command.Handle();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAuthor(int id)
    {
        try
        {
            DeleteAuthorCommand command = new(context)
            {
                AuthorId = id
            };
            DeleteAuthorCommandValidator validator = new();
            validator.ValidateAndThrow(command);
            command.Handle();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return Ok();
    }

}

