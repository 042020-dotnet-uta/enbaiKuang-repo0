using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Text;
using Project0.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project0.UI
{
    class MainPage : UI
    {
        public void display() {
            while (true) {
                Console.Clear();
                Console.WriteLine("Please enter a number for your selection.");
                Console.WriteLine("1.Add new customer information\n2.Add new store information" +
                    "\n3.Returning customers\n4.Select store to shop at\n5.Exit Program");
                string input = Console.ReadLine();
                int.TryParse(input, out int result);
                switch (result)
                {
                    case 1:
                        newCustomer();
                        break;
                    case 2:
                        newStore();
                        break;
                    case 3:
                        CustomerUI startCusUI = new CustomerUI();
                        startCusUI.display();
                        break;
                    case 4:
                        StoreUI startStoUI = new StoreUI();
                        startStoUI.display();
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

        public void newStore() {
            using (P0DbContext db = new P0DbContext()) {
                try {
                    Console.WriteLine("Please enter a store location");
                    string loc = Console.ReadLine();
                    Store newStore = new Store();
                    newStore.Location = loc;
                    db.Add<Store>(newStore);
                    db.SaveChanges();
                    Console.WriteLine("Store added. Press Enter to return to main menu.");
                    Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception occurred: {e}");
                    return;
                }
            }
        }

        public void newCustomer() {
            using (P0DbContext db = new P0DbContext()) {

                try {
                    Console.WriteLine("Please enter First and Last Name with space seperating them.");
                    string input = Console.ReadLine();
                    string[] name = input.Split(' ');
                    Console.WriteLine("Please enter a valid phone number");
                    input = Console.ReadLine();
                    int.TryParse(input, out int result);
                    Customer newCustomer = new Customer();
                    newCustomer.FirstName = name[0];
                    newCustomer.LastName = name[1];
                    newCustomer.PhoneNumber = result;
                    db.Add<Customer>(newCustomer);
                    db.SaveChanges();
                    Console.WriteLine("Customer added. Press Enter to return to main menu.");
                    Console.ReadLine();
                }
                catch(Exception e) {
                    Console.WriteLine($"Exception occurred: {e}");
                    Console.ReadLine();
                    return;
                }
            }
        }
    }
}
