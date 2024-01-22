using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Movies.Entities;

public class Author
{
    //Auto-Increment
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id{get; set;}
    public string Name {get; set;}
    public string Surname {get; set;}
    public DateTime DateofBirth {get; set;}
    public bool IsActive {get; set;} = true;
}
