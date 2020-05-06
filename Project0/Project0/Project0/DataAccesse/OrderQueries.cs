using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Project0.Models;

namespace Project0.DataAccess
{
    class OrderQueries
    {

        public ICollection<Order> GetOrders()
        {
            using (P0DbContext db = new P0DbContext())
            {
                try
                {
                    return db.Orders
                    .AsNoTracking()
                    .ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception occurred: {e}");
                    return null;
                }
            }
        }

        public bool existsOrder(int id){
            using (P0DbContext db = new P0DbContext()){
                try{
                    var ret = db.Orders
                   .Where(o => o.OrderID == id);
                    return !(ret.Count() == 0);
                }
                catch (Exception e){
                    Console.WriteLine($"Exception occurred: {e}");
                    return false;
                }
            }
        }

        public ICollection<Order> orderDetails(int id){
            using (P0DbContext db = new P0DbContext()){
                try{
                    var order = db.Orders
                    .AsNoTracking()
                    .Where(o => o.OrderID == id)
                    .FirstOrDefault();
                    var time = order.Time;

                    return db.Orders
                        .AsNoTracking()
                        .Where(o => o.Time == time)
                        .Include(customer => customer.Customer)
                        .Include(order => order.Product)
                        .ThenInclude(product => product.Store)
                        .ToList();
                }
                catch (Exception e){
                    Console.WriteLine($"Exception occurred: {e}");
                    return null;
                }
            }
        }
    }
}
