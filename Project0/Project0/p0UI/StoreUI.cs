using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Project0.DataAccess;
using System.Linq;

namespace Project0.UI
{
    class StoreUI : UI
    {
        public void display() {
            while (true) {
                Console.Clear();
                Console.WriteLine("Please enter a number for your selection.");
                Console.WriteLine("1. View Store History\n2.View Store Products" +
                    "\n3.View all stores\n4.Return to Main Menu");
                string input = Console.ReadLine();
                int.TryParse(input, out int result);
                switch (result)
                {
                    case 1:
                        showOrderHistory();
                        break;
                    case 2:
                        showStoreProducts();
                        break;
                    case 3:
                        viewAllStores();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Invalid Input, Press enter to try again.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        public void showStoreProducts() {
            int storeID = 0;
            StoreQueries stores = new StoreQueries();

            #region get storeID
            Console.WriteLine("Please enter a StoreID for the location you would like to place your order at");
            string input = Console.ReadLine();
            bool invalid = true;
            int result;
            while (invalid)
            {
                if (!int.TryParse(input, out result) || !stores.existsStore(result))
                {
                    Console.WriteLine("Invalid Input, Please try again.");
                    input = Console.ReadLine();
                }
                else
                {
                    storeID = result;
                    invalid = false;
                }
            }
            #endregion

            #region display products
            ProductQueries products = new ProductQueries();
            var productList = products.getProducts(storeID);

            Console.Clear();
            Console.WriteLine("ID\tStore\t\tName\t\tInventory\tPrice");
            foreach (var p in productList)
            {
                Console.WriteLine($"{p.ProductID}\t{p.Store.Location}\t{p.Name}" +
                    $"\t{p.Inventory}\t\t{p.Price}");
            }
            #endregion

            Console.WriteLine("Press enter to return to the menu");
            Console.ReadLine();
        }

        public void viewAllStores() {
            Console.Clear();
            StoreQueries storeHistory = new StoreQueries();

            var stores = storeHistory.getStores();
            Console.WriteLine("ID\tLocation");
            foreach (var s in stores)
            {
                Console.WriteLine($"{s.StoreID}\t{s.Location}");
            }
            Console.WriteLine("Press enter to return to the menu");
            Console.ReadLine();
        }

        public void showOrderHistory() {
            Console.Clear();
            StoreQueries storeHistory = new StoreQueries();

            var stores = storeHistory.getStores();
            Console.WriteLine("ID\tLocation");
            foreach (var s in stores)
            {
                Console.WriteLine($"{s.StoreID}\t{s.Location}");
            }

            Console.WriteLine("Please Enter the ID of the Store you would like to view History of");
            string input = Console.ReadLine();
            int.TryParse(input, out int result);

            if (storeHistory.existsStore(result))
            {
                var orders = storeHistory.getHistory(result);
                var loc = storeHistory.getLocation(result);
                if (orders.Count() == 0)
                {
                    Console.WriteLine($"No orders has been made to {loc} ");
                }
                else
                {
                    Console.WriteLine($"Order history for {result} {loc}");
                    Console.WriteLine("Customer\tProduct\t\tQuantity\tTotal\t\tTime");
                    foreach (var o in orders)
                    {
                        double price = o.Product.Price * o.Count;
                        Console.WriteLine($"{o.Customer.FirstName} {o.Customer.LastName}\t" +
                            $"{o.Product.Name}\t{o.Count}" +
                            $"\t\t${price}\t\t{o.Time}");
                    }
                }
                Console.WriteLine("Press enter to return to the menu");
                Console.ReadLine();
            }
        }
    }
}
