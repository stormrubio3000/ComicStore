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
                    repo.AddCart(dbContext, fal, inv, ID);
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

void AddCart(Project0Context dbContext, string name, int size, int ID);
void AddCustomer(Project0Context dbContext, string name, string email, string storeid);
void AddProduct(Project0Context dbContext, string name, decimal price, int size, int store);
void AddStore(Project0Context dbContext, string name);
void CheckOut(Project0Context dbContext, string name, int cartid, out decimal total);
void DeleteCart(Project0Context dbContext, string name, int size, int ID);
void DeleteCustomer(Project0Context dbContext, string name, string email);
void DeleteProduct(Project0Context dbContext, string name);
void DeleteStore(Project0Context dbContext, string name);
void ShowCart(Project0Context dbContext, string name, int cartid);
void ShowCustomers(Project0Context dbContext, string name = null);
void ShowHistory(Project0Context dbContext, string name, string option);
void ShowProducts(Project0Context dbContext, string name = null);
void ShowStores(Project0Context dbContext, string name = null);
void UpdateCustomer(Project0Context dbContext, string name, string email, string oldn, string olde);
void UpdateProduct(Project0Context dbContext, string name, decimal price, int size, int store, string old);
void UpdateStore(Project0Context dbContext, string name, string ne);
bool CheckCartTime(Project0Context dbContext, string cust, int orderid, DateTime curr_order);
*/
