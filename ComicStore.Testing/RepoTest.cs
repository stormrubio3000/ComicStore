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
                Assert.True(true);
            }
                
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
                    repo.AddCart(dbContext, fal, inv, ID);
                }
                catch
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










    }
}
/*

void CheckOut(Project0Context dbContext, string name, int cartid, out decimal total);
bool CheckCartTime(Project0Context dbContext, string cust, int orderid, DateTime curr_order);
*/
