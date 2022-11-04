using System;
using ConsoleAppDb.DAL;
using ConsoleAppDb.Domain;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, DB Demo!");

//Data Source=/Users/janaf/Documents/temp_IT/app.db

var options =
    new DbContextOptionsBuilder<AppDbContext>()
        .UseSqlite("Data Source=/Users/janaf/Documents/temp_IT/app.db")
.Options;

// ctx = 
using var ctx = new AppDbContext(options);

var p = new Person()
{
    FirstName = "James",
    LastName = "Issac"
};

var c = new Course()
{
    CourseName = "Math"
};

p.PersonCourses = new List<PersonCourse>()
{
    new PersonCourse()
    {
        Course = c,
        Person = p
    }
};


ctx.Persons.Add(p);
ctx.SaveChanges();

foreach (var person in ctx
             .Persons
             .Include(p => p.PersonCourses)
             .ThenInclude(pc => pc.Course)
             .Where(p => p.FirstName.Contains("dr"))
         )
{
    Console.WriteLine(person);
    Console.WriteLine($"Courses: {person.PersonCourses?.Count.ToString() ?? "null"}");
    if (person.PersonCourses != null)
    {
        foreach (var personCourse in person.PersonCourses)
        {
            Console.WriteLine(personCourse.Course!.CourseName);
        }
    }

}

foreach (var course in ctx.Courses)
{
    Console.WriteLine(course.CourseName);
}

