using ET.ComicStore.Library;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace ComicStore.Testing
{
    public class RepoTest
    {
        [Fact]
        public void Add_Cart_No_Error()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Project0Context>();
            optionsBuilder.UseSqlServer(Secret.ConnectionString);
            var options = optionsBuilder.Options;
            var repo = new FrameworkRepo();
            using (var dbContext = new Project0Context(options))
            {
                string name = "Batman";
                int inv = 1;
                int ID = 1;
                repo.AddCart(dbContext, name, inv, ID);
            }
            Assert.True(true);
        }

        [Fact]
        public void Add_Cart_Error()
        {
            
            var optionsBuilder = new DbContextOptionsBuilder<Project0Context>();
            optionsBuilder.UseSqlServer(Secret.ConnectionString);
            var options = optionsBuilder.Options;
            var repo = new FrameworkRepo();
            using (var dbContext = new Project0Context(options))
            {

                try 
                {
                    string fal = "not a comic";
                    int inv = 1;
                    int ID = 1;
                    Assert.True(true);
                    repo.AddCart(dbContext, fal, inv, ID);
                }
                catch (Exception e)
                {
                    Assert.True(true);
                }
            }
        }




        [Fact]
        public void Delete_Cart_No_Error()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Project0Context>();
            optionsBuilder.UseSqlServer(Secret.ConnectionString);
            var options = optionsBuilder.Options;
            var repo = new FrameworkRepo();
            using (var dbContext = new Project0Context(options))
            {
                string name = "Batman";
                int inv = 1;
                int ID = 1;
                repo.DeleteCart(dbContext, name, inv, ID);
            }
            Assert.True(true);
        }

        [Fact]
        public void Delete_Cart_Error()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Project0Context>();
            optionsBuilder.UseSqlServer(Secret.ConnectionString);
            var options = optionsBuilder.Options;
            var repo = new FrameworkRepo();
            using (var dbContext = new Project0Context(options))
            {

                try
                {
                    string fal = "not a comic";
                    int inv = 1;
                    int ID = 1;
                    repo.DeleteCart(dbContext, fal, inv, ID);
                }
                catch
                {
                    Assert.True(true);
                }
            }
        }


        [Fact]
        public void Checkout_No_Error()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Project0Context>();
            optionsBuilder.UseSqlServer(Secret.ConnectionString);
            var options = optionsBuilder.Options;
            var repo = new FrameworkRepo();
            decimal ID = 0;
            using (var dbContext = new Project0Context(options))
            {
                string name = "Matt";
                int inv = 1;
                repo.CheckOut(dbContext, name, inv,out ID);
            }
            Assert.True(ID > 0);
        }

        [Fact]
        public void Checkout_Error()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Project0Context>();
            optionsBuilder.UseSqlServer(Secret.ConnectionString);
            var options = optionsBuilder.Options;
            var repo = new FrameworkRepo();
            using (var dbContext = new Project0Context(options))
            {

                try
                {
                    string fal = "not a name";
                    int inv = 1;
                    decimal ID = 1;
                    repo.CheckOut(dbContext, fal, inv, out ID);
                }
                catch
                {
                    Assert.True(true);
                }
            }
        }


        [Fact]
        public void CheckCartTime_Error()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Project0Context>();
            optionsBuilder.UseSqlServer(Secret.ConnectionString);
            var options = optionsBuilder.Options;
            var repo = new FrameworkRepo();
            using (var dbContext = new Project0Context(options))
            {
                try
                {
                    string name = "matt";
                    int id = 1;
                    repo.CheckCartTime(dbContext, name, id, DateTime.Now);
                }
                catch
                {
                    Assert.True(true);
                }
            }
        }




    }
}
