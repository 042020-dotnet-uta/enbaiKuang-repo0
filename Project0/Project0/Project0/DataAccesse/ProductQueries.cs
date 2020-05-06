using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Project0.Models;

namespace Project0.DataAccess
{
    public class ProductQueries
    {
        public ICollection<Product> getProducts(){
            using (P0DbContext db = new P0DbContext())
            {
                try{
                    return db.Products
                    .AsNoTracking()
                    .Include(p => p.Store)
                    .ToList();
                }
                catch (Exception e){
                    Console.WriteLine($"Exception occurred: {e}");
                    return null;
                }
            }
        }

        public ICollection<Product> getProducts(int storeID)
        {
            using (P0DbContext db = new P0DbContext())
            {
                try
                {
                    return db.Products
                    .AsNoTracking()
                    .Include(p => p.Store)
                    .Where(p => p.Store.StoreID == storeID)
                    .ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception occurred: {e}");
                    return null;
                }
            }
        }

        public bool existsProduct(int id){
            using (P0DbContext db = new P0DbContext()){
                try{
                    var check = db.Products
                    .Where(c => c.ProductID == id);

                    var inventoryCheck = db.Products
                        .AsNoTracking()
                        .Where(c => c.ProductID == id)
                        .FirstOrDefault();
                    if (check.Count() == 0 || inventoryCheck.Inventory == 0){
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

        public Product getName(int id){
            using (P0DbContext db = new P0DbContext()){
                try{
                    return db.Products
                    .AsNoTracking()
                    .Where(p => p.ProductID == id)
                    .FirstOrDefault();
                }
                catch (Exception e){
                    Console.WriteLine($"Exception occurred: {e}");
                    return null;
                }
            }
        }

        public bool checkCount(int productId, int count){
            using (P0DbContext db = new P0DbContext()){
                try{
                    var check = db.Products
                   .Where(p => p.ProductID == productId)
                   .FirstOrDefault();
                    if (check.Inventory < count){
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
    }
}
