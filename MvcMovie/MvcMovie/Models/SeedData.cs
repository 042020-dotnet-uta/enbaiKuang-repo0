using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider) {
            using (var context = new MvcMovieContext
                (serviceProvider.GetRequiredService < DbContextOptions<MvcMovieContext>>())) {
                if (context.Movie.Any()) {
                    return;
                }

                context.Movie.AddRange(
                    new Movie { 
                        Title = "Silence of the Lambs",
                        ReleaseDate = DateTime.Parse("1991-1-30"),
                        Genre = "Psychological Horror",
                        Price = 9.99M
                    },
                    new Movie
                    {
                        Title = "My Fair Lady",
                        ReleaseDate = DateTime.Parse("1964-10-21"),
                        Genre = "Musical Comedy",
                        Price = 9.99M
                    },
                    new Movie
                    {
                        Title = "Singing in the Rain",
                        ReleaseDate = DateTime.Parse("1952-3-27"),
                        Genre = "Musical Comedy",
                        Price = 9.99M
                    },
                    new Movie
                    {
                        Title = "I Love Melvin",
                        ReleaseDate = DateTime.Parse("1953-3-20"),
                        Genre = "Dancing Comedy",
                        Price = 9.99M
                    }
                    );

                context.SaveChanges();
            }
        }
    }
}
