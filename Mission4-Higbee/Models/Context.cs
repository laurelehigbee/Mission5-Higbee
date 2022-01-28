using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission5_Higbee.Models 
{
    public class Context : DbContext //context for the database
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<MovieResponse> Responses { get; set; } //where to get what's going into the database
        public DbSet<Category>Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Action/Adventure" },
                new Category { CategoryId = 2, CategoryName = "Family" },
                new Category { CategoryId = 3, CategoryName = "Comedy" },
                new Category { CategoryId = 4, CategoryName = "Drama" },
                new Category { CategoryId = 5, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 6, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 7, CategoryName = "Television" },
                new Category { CategoryId = 8, CategoryName = "VHS" }
                );
    
            mb.Entity<MovieResponse>().HasData( //assigns the data to the db
                new MovieResponse //first response seeded in
                {
                    MovieSubmissionId=1,
                    CategoryId = 2,
                    Title = "Frozen",
                    Year = 2013,
                    Director = "Chris Buck and Jennifer Lee",
                    Rating = "PG",
                    Edited = false,
                    Lent_to = "",
                    Notes = ""
                },
                new MovieResponse //second response seeded in
                {
                    MovieSubmissionId=2,
                    CategoryId = 1,
                    Title = "Captain America: The Winter Soldier",
                    Year = 2014,
                    Director = "Joe and Anthony Russo",
                    Rating = "PG-13",
                    Edited = false,
                    Lent_to = "",
                    Notes = ""
                },
                new MovieResponse //final movie response seeded in
                {
                    MovieSubmissionId=3,
                    CategoryId = 1,
                    Title = "Demon Slayer: Mugen Train",
                    Year = 2020,
                    Director = "Haruo Sotozaki",
                    Rating = "R",
                    Edited = false,
                    Lent_to = "",
                    Notes = ""
                }
            );
        }
    }
}

