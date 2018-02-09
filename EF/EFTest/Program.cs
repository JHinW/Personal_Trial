using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EFTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            // insertPosts();

            Task.Run(() =>
            {
                using (var db = new BloggingContext())
                {
                    var serviceProvider = db.GetInfrastructure<IServiceProvider>();
                    var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                    loggerFactory.AddProvider(new MyLoggerProvider());


                    //includeTest(db);
                    Cascading(db);

                }

            }).Wait();

        }

        static void insertPosts(BloggingContext db)
        {
            // db.Database.EnsureCreated();


            db.Posts.Add(new Post
            {
                BlogId = 1,
                Title = "sssss1"
            });

            db.Posts.Add(new Post
            {
                BlogId = 2,
                Title = "sssss2"
            });

            db.Posts.Add(new Post
            {
                BlogId = 3,
                Title = "sssss3"
            });
            var count = db.SaveChanges();
            Console.WriteLine("{0} records saved to database", count);

            Console.WriteLine();
            Console.WriteLine("All blogs in database:");
            foreach (var blog in db.Blogs)
            {
                Console.WriteLine(" - {0}", blog.Url);
            }
        }

        static async void includeTest(BloggingContext db)
        {
          // db.Database.EnsureCreated();
            var blogs = await db.Blogs
                   .Include(blog => blog.Posts)
                  .ToListAsync();
        }


        static async void transaction(BloggingContext db)
        {
            // https://docs.microsoft.com/en-us/ef/core/saving/transactions
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    try
                    {
                        db.Blogs.Add(new Blog { Url = "http://blogs.msdn.com/dotnet" });
                        db.SaveChanges();

                        db.Blogs.Add(new Blog { Url = "http://blogs.msdn.com/visualstudio" });
                        db.SaveChanges();

                        var blogs = await db.Blogs
                            .OrderBy(b => b.Url)
                            .ToListAsync();

                        // Commit transaction if all commands succeed, transaction will auto-rollback
                        // when disposed if either commands fails
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        // TODO: Handle failure
                    }

                }
                catch (Exception)
                {
                    // TODO: Handle failure
                    transaction.Rollback();
                }

            }

        }

        static void Cascading(BloggingContext db)
        {
            var blog = db.Blogs.Include(b => b.Posts).First();
            db.Remove(blog);
            db.SaveChanges();
        }
    }
}
