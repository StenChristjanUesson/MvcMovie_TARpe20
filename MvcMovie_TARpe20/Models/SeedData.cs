using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie_TARpe20.Data;
using MvcMovie_TARpe20.Models;
using System;
using System.Linq;

namespace MvcMovie_TARpe20
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovie_TARpe20Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovie_TARpe20Context>>()))
            {
                // Look for any movies.
                if (!context.Movie.Any())
                {

                    AddMovies(context);   // DB has been seeded
                }
                context.SaveChanges();

                if (!context.Actor.Any())
                {
                    AddActors(context);
                }

                context.SaveChanges();


            }

        }

        private static void AddMovies(MvcMovie_TARpe20Context context)
        {
            context.Movie.AddRange(
                 new Movie
                 {
                     Title = "how to train your dragon",
                     ReleaseDate = DateTime.Parse("2-4-2010"),
                     Genre = "Adventure Children's film",
                     Rating = "PG",
                     Price = 10
                 },

                 new Movie
                 {
                     Title = "Percy Jackson The Lightning thief",
                     ReleaseDate = DateTime.Parse("14-2-2010"),
                     Genre = "Adventure Fantasy",
                     Rating = "PG",
                     Price = 10
                 },

                 new Movie
                 {
                     Title = "hobbs and shaw",
                     ReleaseDate = DateTime.Parse("2-8-2019"),
                     Genre = "Buddy cop Action",
                     Rating = "PG-13",
                     Price = 15

                 },

                 new Movie
                 {
                     Title = "IT",
                     ReleaseDate = DateTime.Parse("8-9-2017"),
                     Genre = "Thriller mystery",
                     Rating = "R",
                     Price = 12
                 }

             );

        }

        public static void AddActors(MvcMovie_TARpe20Context context)
        {
            context.Actor.AddRange(
                  new Actor
                  {
                      FirstName = "Dwayne",
                      LastName = "Johnson",
                      DateOfBirth = DateTime.Parse("2-5-1972"),
                      NumberOfOscars = 0,
                      BirthPlace = "california",
                      NetWorth = 350000000
                  },

                  new Actor
                  {
                      FirstName = "Jackie",
                      LastName = "Chan",
                      DateOfBirth = DateTime.Parse("7-4-1954"),
                      NumberOfOscars = 1,
                      BirthPlace = "hong kong",
                      NetWorth = 350000000

                  },


                  new Actor
                  {
                      FirstName = "jason",
                      LastName = "statham",
                      DateOfBirth = DateTime.Parse("5-2-1995"),
                      NumberOfOscars = 1,
                      BirthPlace = "England",
                      NetWorth = 1500000000
                  },

                  new Actor
                  {
                      FirstName = "robert",
                      LastName = "juunior",
                      DateOfBirth = DateTime.Parse("4-4-1965"),
                      NumberOfOscars = 2,
                      BirthPlace = "New York",
                      NetWorth = 300000000
                  }
                  );
        }
    }
}



    
