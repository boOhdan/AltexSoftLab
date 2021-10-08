using FoodOrderingSystem.Models;
using System.Collections.Generic;

namespace FoodOrderingSystem.Date
{
    public class AppStore
    {
        public List<ProductCategory> ProductCategories { get; set; }
        public List<Product> Products { get; set; }
        public List<Supplier> Suppliers { get; set; }

        public AppStore() 
        {
            ProductCategories = new List<ProductCategory>
            {
                new() { Name = "breads"},
                new() { Name = "vegetables"},
                new() { Name = "fruit"},
                new() { Name = "milk"},
                new() { Name = "meat"},
                new() { Name = "legumes"},
                new() { Name = "grains"},
            };

            Products = new List<Product>
            {
                new() 
                {
                    Name = "Porkish",
                    Description = "porkish, porkish, porkish",
                    Price = 120,
                    Quantity = 45,
                    ProductCategories = new()
                    {
                        ProductCategories[4]
                    }
                },

                new()
                {
                    Name = "Meatcuts",
                    Description = "meatcuts, meatcuts, meatcuts",
                    Price = 164,
                    Quantity = 36,
                    ProductCategories = new()
                    {
                        ProductCategories[4]
                    }
                },

                new()
                {
                    Name = "Meatmash",
                    Description = "meatmash, meatmash, meatmash",
                    Price = 240,
                    Quantity = 21,
                    ProductCategories = new()
                    {
                        ProductCategories[4]
                    }
                },

                new()
                {
                    Name = "Breado",
                    Description = "breado, breado, breado",
                    Price = 18,
                    Quantity = 40,
                    ProductCategories = new()
                    {
                        ProductCategories[0]
                    }
                },

                new()
                {
                    Name = "Lolate",
                    Description = "lolate, lolate, lolate",
                    Price = 38,
                    Quantity = 57,
                    ProductCategories = new()
                    {
                        ProductCategories[1]
                    }
                },

                new()
                {
                    Name = "Vegang",
                    Description = "vegang, vegang, vegang",
                    Price = 86,
                    Quantity = 72,
                    ProductCategories = new()
                    {
                        ProductCategories[5]
                    }
                },

                new()
                {
                    Name = "Elegum",
                    Description = "elegum, elegum, elegum",
                    Price = 94,
                    Quantity = 26,
                    ProductCategories = new()
                    {
                        ProductCategories[5]
                    }
                }
            };

            Suppliers = new List<Supplier>
            {
                new() 
                { 
                    Name = "Oleh", 
                    Email = "sirigis811@hyprhost.com", 
                    Password = "*RC@iS*9UC", 
                    Products = new() 
                    {
                        Products[0],
                        Products[2],
                        Products[3],
                    } 
                },
                new()
                {
                    Name = "Bohdan",
                    Email = "lowojod388@flipssl.com",
                    Password = "*u%@RbbtZIT",
                    Products = new()
                    {
                        Products[0],
                        Products[1],
                        Products[3],
                        Products[5],
                    }
                },
                new()
                {
                    Name = "Igor",
                    Email = "jaleta5724@biohorta.com",
                    Password = "mCbY#M!gYN",
                    Products = new()
                    {
                        Products[4],
                        Products[6],
                    }
                }
            };
        }

    }
}
