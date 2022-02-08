using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission5.Models
{
    public class MovieFormContext : DbContext
    {

        public MovieFormContext(DbContextOptions<MovieFormContext> options) : base(options)
        {

        }

        public DbSet<MovieForm> Responses { get; set; }
        public DbSet<Category> Category { get; set; }


        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(

                new Category { CategoryId = 1, CategoryName = "Action/Adventure" },
                new Category { CategoryId = 2, CategoryName = "Comedy" },
                new Category { CategoryId = 3, CategoryName = "Drama" },
                new Category { CategoryId = 4, CategoryName = "Family" },
                new Category { CategoryId = 5, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 6, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 7, CategoryName = "Television" },
                new Category { CategoryId = 8, CategoryName = "VHS" }
            );


            mb.Entity<MovieForm>().HasData(

                    new MovieForm
                    {
                        MovieId = 1,
                        Title = "About Time",
                        CategoryId = 3,
                        Year = 2013,
                        Director = "Richard Curtis",
                        Rating = "R",
                        Edited = false,
                        Lent_To = "Sharon Meyers",
                        Notes = "A movie about Time Travel, and cancer"
                    },
                    new MovieForm
                    {
                        MovieId = 2,
                        Title = "Good Will Hunting",
                        CategoryId = 3,
                        Year = 1997,
                        Director = "Gus Van Sant",
                        Rating = "R",
                        Edited = false,
                        Lent_To = "Sharon Meyers",
                        Notes = "He stole my line"
                    },
                    new MovieForm
                    {
                        MovieId = 3,
                        Title = "Spider-Man: No Way Home",
                        CategoryId = 1,
                        Year = 2021,
                        Director = "Jon Watts",
                        Rating = "PG-13",
                        Edited = false,
                        Lent_To = "Sharon Meyers",
                        Notes = "It has Three Spiders"
                    }
                );


        }
    }
}
