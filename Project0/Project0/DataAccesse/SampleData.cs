using System;
using System.Collections.Generic;
using System.Text;
using Project0.Models;

namespace Project0.DataAccess
{
    class SampleData
    {
        public void addSamples()
        {
            using (P0DbContext db = new P0DbContext()){
                    db.Add(new Store { Location = "Seattle" });
                    db.Add(new Store { Location = "Los Santos" });
                    db.Add(new Store { Location = "Velen" });
                    db.SaveChanges();

                    db.Add(new Product { Name = "SampleProduct11", StoreID = 1, Inventory = 5, Price = 2.50 });
                    db.Add(new Product { Name = "SampleProduct12", StoreID = 1, Inventory = 10, Price = 5.00 });
                    db.Add(new Product { Name = "SampleProduct21", StoreID = 2, Inventory = 15, Price = 10.00 });
                    db.Add(new Product { Name = "SampleProduct22", StoreID = 2, Inventory = 20, Price = 20.00 });
                    db.Add(new Product { Name = "SampleProduct31", StoreID = 3, Inventory = 25, Price = 50.00 });
                    db.Add(new Product { Name = "SampleProduct32", StoreID = 3, Inventory = 30, Price = 100.00 });
                    db.SaveChanges();
            }
        }
    }
}
