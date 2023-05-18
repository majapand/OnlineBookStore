using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing;
using MVCBookStore.Data;
using System.Diagnostics.Metrics;
using System;
using System.IO;
using System.Numerics;
using System.Security.Claims;
using System.Security.Policy;
using Microsoft.AspNetCore.Identity;
using MVCBookStore.Areas.Identity.Data;

namespace MvcProekt.Models
{
    public class SeedData
    {
        public static async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<MVCBookStoreUser>>();
            IdentityResult roleResult;
            //Add Admin Role
            var roleCheck = await RoleManager.RoleExistsAsync("Admin");
            if (!roleCheck) { roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin")); }
            MVCBookStoreUser user = await UserManager.FindByEmailAsync("admin@mvcbookstore.com");
            if (user == null)
            {
                var User = new MVCBookStoreUser();
                User.Email = "admin@mvcbookstore.com";
                User.UserName = "admin@mvcbookstore.com";
                string userPWD = "Admin123";
                IdentityResult chkUser = await UserManager.CreateAsync(User, userPWD);
                //Add default User to Role Admin
                if (chkUser.Succeeded) { var result1 = await UserManager.AddToRoleAsync(User, "Admin"); }
            }

            var roleCheck2 = await RoleManager.RoleExistsAsync("User");
            if (!roleCheck2) { roleResult = await RoleManager.CreateAsync(new IdentityRole("User")); }
            MVCBookStoreUser user2 = await UserManager.FindByEmailAsync("user@mvcproekt.com");
            if (user2 == null)
            {
                var User = new MVCBookStoreUser();
                User.Email = "user@mvcproekt.com";
                User.UserName = "user@mvcproekt.com";
                string userPWD = "User123";
                IdentityResult chkUser = await UserManager.CreateAsync(User, userPWD);
                //Add default User to Role Admin
                if (chkUser.Succeeded)
                {
                    await UserManager.AddToRoleAsync(User, "User");
                }
            }
        }

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MVCBookStoreContext(
                serviceProvider.GetRequiredService<DbContextOptions<MVCBookStoreContext>>()))
            {
                CreateUserRoles(serviceProvider).Wait();

                if (context.Book.Any() || context.Author.Any() || context.Genre.Any() || context.Review.Any() || context.UserBook.Any())
                {
                    return;   // DB has been seeded
                }
                context.Author.AddRange(
                    new Author { /*Id = 1, */FirstName = "Paulo", LastName = " Coelho", BirthDate = DateTime.Parse("1948-9-20"), Nationality = "American", Gender = "Male" },
                    new Author { /*Id = 2, */FirstName = "Dan", LastName = "Brown", BirthDate = DateTime.Parse("1920-8-1"), Nationality = "American", Gender = "Male" },
                    new Author { /*Id = 3, */FirstName = "Miguel", LastName = "De Cervantes", BirthDate = DateTime.Parse("1920-10-8"), Nationality = "American", Gender = "Male" }
                );
                context.SaveChanges();

                context.Genre.AddRange(
                    new Genre { /*Id = 1, */GenreName = "Novel" },
                    new Genre { /*Id = 2, */GenreName = "Fictiom" },
                    new Genre { /*Id = 3, */GenreName = "Horror" },
                    new Genre { /*Id = 4, */GenreName = "Romantic" },
                    new Genre { /*Id = 5, */GenreName = "Action" },
                    new Genre { /*Id = 6, */GenreName = "Tragedy" },
                    new Genre { /*Id = 7, */GenreName = "History" },
                    new Genre { /*Id = 8, */GenreName = "Science" },
                   
                );
                context.SaveChanges();

               \
                context.Book.AddRange(
                    
        
                    new Book
                    {
                        //Id = 1,
                        Title = "The Alchemist",
                        YearPublished = 1998,
                        NumPages = 350,
                        Description = "hdhafkjhn"alchemist.jpg",
                        DownloadUrl = " ",
                        AuthorId = 1
                    },
                    new Book
                    {
                        //Id = 2,
                        Title = "Da Vinci Code",
                        YearPublished = 1999,
                        NumPages = 400,
                        Description = "nkjfgn"
                        FrontPage = "DaVinciCode.jpg",
                        DownloadUrl = "",
                        AuthorId = 1
                    },
                    new Book
                    {
                        //Id = 3,
                        Title = "Harry Potter",
                        YearPublished = 1980,
                        NumPages = 350,
                        Description = "few",
                        Publisher = " ",
                        FrontPage = "Harry.jpg",
                        DownloadUrl = "",
                        AuthorId = 2
                    },
                    new Book
                    {
                        //Id = 4,
                        Title = "The little prince",
                        YearPublished = 1965,
                        NumPages = 215,
                        Description = "bvjv",
                        Publisher = " ",
                        FrontPage = "LittlePrince.jpg",
                        DownloadUrl = " ",
                        AuthorId = 2
                    },
                    new Book
                    {
                        //Id = 5,
                        Title = "The Hobbit",
                        YearPublished = 1956,
                        NumPages = 155,
                        Description = "",
                        Publisher = "bhj",
                        FrontPage = "thehobbit.jpeg",
                        DownloadUrl = " ",
                        AuthorId = 2
                    },
                    new Book
                    {
                        //Id = 6,
                        Title = "Lord Of the Rings",
                        YearPublished = 1970,
                        NumPages = 270,
                        Description = "  ",
                        Publisher = "jkn",
                        FrontPage = "lord.jpg",
                        DownloadUrl = " ",
                        AuthorId = 3
                    }
                   
                );

                context.SaveChanges();

               context.Review.AddRange(
                    new Review
                    {
                        /*Id = 1, */
                        BookId = 1,
                        AppUser = "Steve",
                        Comment = " I loved it!",
                        Rating = 10
                    },
                    new Review
                    {
                        /*Id = 2, */
                        BookId = 7,
                        AppUser = "Steve",
                        Comment = "Great.",
                        Rating = 2
                    },
                    new Review
                    {
                        /*Id = 3, */
                        BookId = 4,
                        AppUser = "Steve",
                        Comment = "Ok",
                        Rating = 8
                    },
                    new Review
                    {
                        /*Id = 4, */
                        BookId = 1,
                        AppUser = "Toni",
                        Comment = "Not that bad!",
                        Rating = 10
                    },
                    new Review
                    {
                        /*Id = 5, */
                        BookId = 2,
                        AppUser = "Toni",
                        Comment = "Great",
                        Rating = 9
                    },
                    new Review
                    {
                        /*Id = 6, */
                        BookId = 3,
                        AppUser = "Toni",
                        Comment = "Great",
                        Rating = 10
                    },
                    new Review
                    {
                        /*Id = 7, */
                        BookId = 4,
                        AppUser = "Elena",
                        Comment = "Good",
                        Rating = 8
                    }
                );
                context.SaveChanges();

                context.UserBook.AddRange(
                    new UserBook {/*Id = 1*/AppUser = "Steve", BookId = 1 },
                    new UserBook {/*Id = 1*/AppUser = "Toni", BookId = 2 },
                    new UserBook {/*Id = 1*/AppUser = "Elena", BookId = 3 }
                    );
                context.SaveChanges();

                context.BookGenre.AddRange(
                new BookGenre { BookId = 1, GenreId = 1 },
                new BookGenre { BookId = 1, GenreId = 9 },
                new BookGenre { BookId = 1, GenreId = 10 },
                new BookGenre { BookId = 1, GenreId = 11 },
                new BookGenre { BookId = 2, GenreId = 1 },
                new BookGenre { BookId = 2, GenreId = 9 },
                new BookGenre { BookId = 2, GenreId = 10 },
                new BookGenre { BookId = 2, GenreId = 11 },
                new BookGenre { BookId = 3, GenreId = 1 },
                new BookGenre { BookId = 3, GenreId = 9 },
                new BookGenre { BookId = 3, GenreId = 10 },
                new BookGenre { BookId = 3, GenreId = 11 },
                new BookGenre { BookId = 4, GenreId = 3 },
                new BookGenre { BookId = 4, GenreId = 5 },
                new BookGenre { BookId = 4, GenreId = 10 },
                new BookGenre { BookId = 5, GenreId = 3 },
                new BookGenre { BookId = 5, GenreId = 5 },
                new BookGenre { BookId = 5, GenreId = 10 },
                new BookGenre { BookId = 6, GenreId = 3 },
                new BookGenre { BookId = 6, GenreId = 5 },
                new BookGenre { BookId = 6, GenreId = 10 },
                new BookGenre { BookId = 7, GenreId = 4 },
                new BookGenre { BookId = 7, GenreId = 5 },
              
                );
                context.SaveChanges();
            }
        }
    }
}
