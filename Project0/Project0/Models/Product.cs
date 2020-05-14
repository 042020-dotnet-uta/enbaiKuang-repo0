using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project0.Models
{
    public class Product
    {
        private int productID;
        public int ProductID
        {
            get { return productID; }
            set { ; }
        }

        private int storeID;
        public int StoreID
        {
            get { return storeID; }
            set { storeID = value; }
        }

        private Store store;
        public Store Store
        {
            get { return store; }
            set { store = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int inventory;
        public int Inventory
        {
            get { return inventory; }
            set { inventory = value; }
        }

        private double price;
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}
