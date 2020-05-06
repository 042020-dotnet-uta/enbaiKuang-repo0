using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Project0.Models
{
    public class Customer
    {
        private int customerID;
        public int CustomerID
        {
            get { return customerID; }
            set {; }
        }
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        private int phoneNumber;
        public int PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
        private ICollection<Order> orders;
        public ICollection<Order> Orders
        {
            get { return orders; }
            set { orders = value; }
        }
    }
}