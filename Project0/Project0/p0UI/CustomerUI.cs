using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Project0.DataAccess;
using Project0.Models;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Project0.UI
{
    class CustomerUI : UI
    {
        public void display() {
            while (true) {
                Console.Clear();
                Console.WriteLine("Welcome to the customers page!" +
                    "\nPlease enter a number for your selection.");
                Console.WriteLine("1.View all Customers\n2. Look up Order History" +
                    "\n3.Place an order\n4.Search by Name\n5.Return to main menu");
                string input = Console.ReadLine();
                int.TryParse(input, out int result);
                switch (result)
                {
                    case 1:
                        showCustomerList();
                        break;
                    case 2:
                        showOrderHistory();
                        break;
                    case 3:
                        placeOrder();
                        break;
                    case 4:
                        lookUpCustomer();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid Input, Press enter to try again.");
                        Console.ReadLine();
                        break;
                }
            }
        }
        public void placeOrder() {
            using (P0DbContext db = new P0DbContext()){
                int storeID = 0;

                Order newOrder = new Order();
                CustomerQueries customers = new CustomerQueries();
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

                #region get customerID
                Console.WriteLine("Please enter the CustomerID of whose placing the order");
                input = Console.ReadLine();
                invalid = true;
                while (invalid)
                {
                    if (!int.TryParse(input, out result) || !customers.existsCustomer(result)){
                        Console.WriteLine("Invalid Input, Please try again.");
                        input = Console.ReadLine();
                    }
                    else{
                        newOrder.CustomerID = result;
                        invalid = false;
                    }
                }
                #endregion

                #region display products
                ProductQueries products = new ProductQueries();
                var productList = products.getProducts(storeID);

                Console.Clear();
                Console.WriteLine("ID\tStore\t\tName\t\tInventory\tPrice");
                foreach (var p in productList){
                    Console.WriteLine($"{p.ProductID}\t{p.Store.Location}\t{p.Name}" +
                        $"\t{p.Inventory}\t\t{p.Price}");
                }
                #endregion

                bool ordering = true;
                int time = 0;
                while (ordering) {
                    #region productID
                    Console.WriteLine("Please enter the productID what you want");
                    input = Console.ReadLine();
                    invalid = true;
                    while (invalid){
                        if (!int.TryParse(input, out result) || !products.existsProduct(result)){
                            Console.WriteLine("Invalid Input, Please try again.");
                            input = Console.ReadLine();
                        }
                        else{
                            newOrder.ProductID = result;
                            invalid = false;
                        }
                    }
                    #endregion

                    #region count
                    Console.WriteLine("Please enter the amount that you want");
                    input = Console.ReadLine();
                    invalid = true;
                    while (invalid)
                    {
                        if (!int.TryParse(input, out result) || !products.checkCount(newOrder.ProductID,result))
                        {
                            Console.WriteLine("Invalid Input, Please try again.");
                            input = Console.ReadLine();
                        }
                        else
                        {
                            newOrder.Count = result;
                            invalid = false;
                        }
                    }
                    #endregion

                    #region keep ordering
                    do
                    {
                        Console.WriteLine("Would you like to keep ordering? Yes : No");
                        input = Console.ReadLine();
                    } while (!(input == "Yes" || input == "No"));

                        if (input == "Yes")
                    {
                        ordering = true;
                    }
                    else ordering = false;

                    time++;
                    if (time == 1) {
                        newOrder.Time = DateTime.Now;
                    }

                    db.Add<Order>(newOrder);
                    db.SaveChanges();

                    StoreQueries update = new StoreQueries();
                    update.placeOrder(newOrder);
                    newOrder.OrderID++;
                    #endregion
                }
                Console.WriteLine("Press enter to return to the menu");
                Console.ReadLine();
            }
        }

        public void showOrderHistory() {
            Console.Clear();
            showCustomerList();
            CustomerQueries customerQuery = new CustomerQueries();

            Console.WriteLine("Please Enter the ID of the Customer you would like to view History of");
            string input = Console.ReadLine();
            int.TryParse(input, out int result);

            if (customerQuery.existsCustomer(result)) {
                var orders = customerQuery.getHistory(result);
                var customer = customerQuery.getCustomer(result);
                if (orders.Count() == 0)
                {
                    Console.WriteLine($"No history Found for {customer.FirstName} {customer.LastName}");
                }
                else {
                    Console.WriteLine($"{customer.FirstName} {customer.LastName}");
                    Console.WriteLine("StoreID\tOrder ID\tProduct\t\tQuantity\tTotal\t\tTime");
                    foreach (var o in orders) {
                        double total = o.Product.Price * o.Count;
                        Console.WriteLine($"{o.Product.Store.StoreID}\t{o.OrderID}\t\t" +
                            $"{o.Product.Name}\t{o.Count}\t\t{total}\t\t{o.Time}");
                    }
                }
                Console.WriteLine("Press enter to return to the menu");
                Console.ReadLine();
            }
        }

        public void showCustomerList() {
            Console.Clear();
            CustomerQueries customerQuery = new CustomerQueries();
            var customerList = customerQuery.getCustomersAll();
            Console.WriteLine("ID\tFirst Name\tLast Name\tPhonenumber");
            foreach (var c in customerList) {
                Console.WriteLine($"{c.CustomerID}\t{c.FirstName}\t{c.LastName}\t{c.PhoneNumber}");
            }
            Console.WriteLine("Press enter to return to the menu");
            Console.ReadLine();
        }

        public void lookUpCustomer() {
            CustomerQueries search = new CustomerQueries();

            Console.WriteLine("Please enter First and Last Name with space seperating them.");
            string input = Console.ReadLine();
            string[] name = input.Split(' ');
            while (name.Count() < 2)
            {
                Console.WriteLine("Invalid input, please try again");
                input = Console.ReadLine();
                name = input.Split(' ');
            }
            var results = search.findCustomer(name[0], name[1]);

            if (results.Count() == 0)
            {
                Console.WriteLine("There are no customers found under that name");
            }
            else {
                Console.WriteLine($"ID\tFirst Name\tLast Name\tPhoneNumber");
                foreach (var c in results)
                {
                    Console.WriteLine($"{c.CustomerID}\t{c.FirstName}" +
                        $"\t\t{c.LastName}\t\t{c.PhoneNumber}");
                }
            }
            Console.WriteLine("Press enter to return to the menu");
            Console.ReadLine();
        }
    }
}
