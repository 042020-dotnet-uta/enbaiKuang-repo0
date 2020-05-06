using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Project0.Models;

namespace Project0.DataAccess
{
    public class CustomerQueries
    {
        public bool existsCustomer(int id)
        {
            using (P0DbContext db = new P0DbContext())
            {
                try
                {
                    var ret = db.Customers
                    .Where(c => c.CustomerID == id);
                    return !(ret.Count() == 0);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception: {e}");
                    return false;
                }
            }
        }

        public ICollection<Customer> findCustomer(string first, string last){
            using (P0DbContext db = new P0DbContext()){             
                try{
                    return db.Customers
                   .AsNoTracking()
                   .Where(c => c.FirstName.Contains(first) && c.LastName.Contains(last))
                   .OrderBy(c => c.FirstName)
                   .ToList();
                }
                catch (Exception e){
                    Console.WriteLine($"Exception: {e}");
                    return null;
                }
            }
        }

        public ICollection<Order> getHistory(int id)
        {
            using (P0DbContext db = new P0DbContext())
            {
                try
                {
                    return db.Orders
                    .AsNoTracking()
                    .Where(o => o.CustomerID == id)
                    .Include(customer => customer.Customer)
                    .Include(order => order.Product)
                    .ThenInclude(product => product.Store)
                    .OrderBy(o => o.Time)
                    .ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception: {e}");
                    return null;
                }
            }
        }

        public ICollection<Customer> getCustomersAll()
        {
            using (P0DbContext db = new P0DbContext())
            {
                try{
                    return db.Customers
                    .AsNoTracking()
                    .ToList();
                }
                catch (Exception e){
                    Console.WriteLine($"Exception: {e}");
                    return null;
                }
            }
        }

        public Customer getCustomer(int id)
        {
            using (P0DbContext db = new P0DbContext())
            {
                try{
                    return db.Customers
                     .AsNoTracking()
                     .Where(c => c.CustomerID == id)
                     .FirstOrDefault();
                }
                catch (Exception e){
                    Console.WriteLine($"Exception: {e}");
                    return null;
                }
            }
        }
    }
}
