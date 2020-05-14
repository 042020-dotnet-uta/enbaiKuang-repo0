using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Project0.Models
{
    public class Order
    {
        private int orderID;
        public int OrderID
        {
            get { return orderID; }
            set { ; }
        }

        private int productID;
        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }

        private Product product;
        public Product Product
        {
            get { return product; }
            set { product = value; }
        }

        private int customerID;
        public int CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }

        private Customer customer;
        public Customer Customer
        {
            get { return customer; }
            set { customer = value; }
        }

        private int count;
        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        private DateTime time;
        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }
    }
}
