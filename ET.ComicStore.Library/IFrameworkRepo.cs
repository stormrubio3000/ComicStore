namespace ET.ComicStore.Library
{
    public interface IFrameworkRepo
    {
        void AddCart(Project0Context dbContext, string name, int size, int ID);
        void AddCustomer(Project0Context dbContext, string name, string email, string storeid);
        void AddProduct(Project0Context dbContext, string name, decimal price, int size, int store);
        void AddStore(Project0Context dbContext, string name);
        void CheckOut(Project0Context dbContext, string name, int cartid, out decimal total);
        void DeleteCart(Project0Context dbContext, string name, int size, int ID);
        void DeleteCustomer(Project0Context dbContext, string name, string email);
        void DeleteProduct(Project0Context dbContext, string name);
        void DeleteStore(Project0Context dbContext, string name);
        void MainMenu();
        void ShowCart(Project0Context dbContext, string name, int cartid);
        void ShowCustomers(Project0Context dbContext, string name = null);
        void ShowHistory(Project0Context dbContext, string name);
        void ShowProducts(Project0Context dbContext, string name = null);
        void ShowStores(Project0Context dbContext, string name = null);
        void UpdateCustomer(Project0Context dbContext, string name, string email, string oldn, string olde);
        void UpdateProduct(Project0Context dbContext, string name, decimal price, int size, int store, string old);
        void UpdateStore(Project0Context dbContext, string name, string ne);
    }
}