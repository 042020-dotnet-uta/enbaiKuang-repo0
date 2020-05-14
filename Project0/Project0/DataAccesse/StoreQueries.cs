using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Project0.Models;

namespace Project0.DataAccess
{
    class StoreQueries
    {
        public ICollection<Store> getStores(){
            using (P0DbContext db = new P0DbContext()){
                try{
                    return db.Stores
                    .AsNoTracking()
                    .ToList();
                }
                catch (Microsoft.Data.Sqlite.SqliteException){
                    Console.WriteLine($"There is no customer table currently.");
                    return null;
                }
                catch (Exception e){
                    Console.WriteLine($"Exception occurred: {e}");
                    return null;
                }
            }
        }

        public bool existsStore(int id){
            using (P0DbContext db = new P0DbContext()){
                try{
                    var check = db.Stores
                    .AsNoTracking()
                    .Where(s => s.StoreID == id);

                    if (check.Count() == 0){
                        return false;
                    }
                    else{
                        return true;
                    }
                }
                catch (Exception e){
                    Console.WriteLine($"Exception occurred: {e}");
                    return false;
                }
            }
        }

        public ICollection<Order> getHistory(int id){
            using (P0DbContext db = new P0DbContext()){
                try{
                    return db.Orders
                    .AsNoTracking()
                    .Where(o => o.Product.StoreID == id)
                    .Include(customer => customer.Customer)
                    .Include(order => order.Product)
                    .OrderBy(o => o.Time)
                    .ToList();
                }
                catch (Exception e){
                    Console.WriteLine($"Exception occurred: {e}");
                    return null;
                }
            }
        }

        public string getLocation(int id){
            using (P0DbContext db = new P0DbContext()){
                try{
                    var store = db.Stores
                     .AsNoTracking()
                     .Where(s => s.StoreID == id)
                     .FirstOrDefault();

                    return store.Location;
                }
                catch (Exception e){
                    Console.WriteLine($"Exception occurred: {e}");
                    return null;
                }
            }
        }

        public void placeOrder(Order newOrder)
        {
            using (P0DbContext db = new P0DbContext())
            {
                try
                {
                    var product = db.Products
                    .Where(p => p.ProductID == newOrder.ProductID)
                    .FirstOrDefault();
                    product.Inventory -= newOrder.Count;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception occurred: {e}");
                }
            }
        }
    }
}
