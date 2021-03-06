using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AspStoreBackend.Models;

namespace AspStoreBackend.Models
{
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        
    }


    public class Products
    {
        public int id { get; set; }
        [ForeignKey("category")]
        public int catId { get; set; }
        public Category category { get; set; }
        public string name { get; set; }

        public string description { get; set; }
        public string image { get; set; }

        public int price { get; set; }
        public int quantity { get; set; }
        
    }


    public class Sales
    {
        public int id { get; set; }
        [ForeignKey("product")]
        public int prodId { get; set; }
        public Products product { get; set; }
        public int price { get; set; }
        
    }

    public class Customer
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        

    }

    public class Cart
    {
        public int id { get; set; }
        public string cartId { get; set; }
        [ForeignKey("customer")]
        public int custId { get; set; }
        public Customer customer { get; set; }
        [ForeignKey("product")]
        public int prodId { get; set; }
        public Products product { get; set; }
        public int quantity { get; set; }
    }




    public class StoreContext : DbContext
    {
        
        public DbSet<Category> categories { get; set; }
        public DbSet<Products> products { get; set; }
        public DbSet<Customer> customer { get; set; }
        public DbSet<Cart> cart { get; set; }
        public DbSet<Sales> sales { get; set; }
        public DbSet<LocationModel> location { get; set; }
        public DbSet<HoursModel> hours { get; set; }  
        public DbSet<UnitedStates> UnitedStates { get; set; }
    }
}