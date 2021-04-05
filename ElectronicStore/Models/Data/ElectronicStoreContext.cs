using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ElectronicStore.Models.Data
{
    public class ElectronicStoreContext : IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<RecommendedProduct> RecommendedProducts { get; set; }
        public DbSet<CategoriesMonth> CategoriesMonth { get; set; }
        
        public ElectronicStoreContext(DbContextOptions options) : base(options)
        {
        }
        
          protected override void OnModelCreating(ModelBuilder builder)
        {
            User user = new User()
            {
                Id = "2d8e581a-3813-44c2-86a4-4d779034541d",
                Name = "Admin",
            };
            base.OnModelCreating(builder);
            builder.Entity<User>().HasData(user);

            List<Category> category = new List<Category>()
            {
                new Category(){Id = 1,Name = "Ноутбуки"},
                new Category(){Id = 2,Name = "Планшеты"},
                new Category(){Id = 3,Name = "Компьютеры"},
            };
            
            base.OnModelCreating(builder);
            builder.Entity<Category>().HasData(category);
            
            List<Subcategory> subcategory = new List<Subcategory>()
            {
                new Subcategory(){Id = 1,Name = "Блоки питания",CategoryId = 1},
                new Subcategory(){Id = 2,Name = "Аккумуляторы",CategoryId = 1},
                new Subcategory(){Id = 3,Name = "Подставки",CategoryId = 1},
                new Subcategory(){Id = 4,Name = "Ноутбуки",CategoryId = 1},
                new Subcategory(){Id = 5,Name = "Сумки",CategoryId = 1},
                
                new Subcategory(){Id = 6,Name = "Планшеты",CategoryId = 2},
                new Subcategory(){Id = 7,Name = "Стилусы",CategoryId = 2},
                new Subcategory(){Id = 8,Name = "Чехлы",CategoryId = 2},
                
                new Subcategory(){Id = 9,Name = "Системные блоки",CategoryId = 3},
                new Subcategory(){Id = 10,Name = "Моноблоки",CategoryId = 3},
                new Subcategory(){Id = 11,Name = "Игровые",CategoryId = 3},
            };
            
            base.OnModelCreating(builder);
            builder.Entity<Subcategory>().HasData(subcategory);
            
            List<Product> products = new List<Product>()
            {
                new Product(){Id = 1,Name = "Oupidatat non",CategoryId = 1,SubcategoryId = 1,Quantity = 10,Price = 250,ImgPath = "assets/img/shop_01.jpg",Description = "text"},
                new Product(){Id = 2,Name = "Oupidatat non",CategoryId = 1,SubcategoryId = 4,Quantity = 6,Price = 250,ImgPath = "assets/img/shop_02.jpg",Description = "text"},
                new Product(){Id = 3,Name = "Oupidatat non",CategoryId = 1,SubcategoryId = 5,Quantity = 9,Price = 250,ImgPath = "assets/img/shop_03.jpg",Description = "text"},
                
                new Product(){Id = 4,Name = "Oupidatat non",CategoryId = 2,SubcategoryId = 6,Quantity = 5,Price = 350,ImgPath = "assets/img/shop_04.jpg",Description = "text"},
                new Product(){Id = 5,Name = "Oupidatat non",CategoryId = 2,SubcategoryId = 7,Quantity = 15,Price = 350,ImgPath = "assets/img/shop_05.jpg",Description = "text"},
                new Product(){Id = 6,Name = "Oupidatat non",CategoryId = 2,SubcategoryId = 8,Quantity = 10,Price = 350,ImgPath = "assets/img/shop_06.jpg",Description = "text"},
                
                new Product(){Id = 7,Name = "Oupidatat non",CategoryId = 3,SubcategoryId = 9,Quantity = 10,Price = 2500,ImgPath = "assets/img/shop_07.jpg",Description = "text"},
                new Product(){Id = 8,Name = "Oupidatat non",CategoryId = 3,SubcategoryId = 10,Quantity = 10,Price = 2500,ImgPath = "assets/img/shop_08.jpg",Description = "text"},
                new Product(){Id = 9,Name = "Oupidatat non",CategoryId = 3,SubcategoryId = 11,Quantity = 1,Price = 2500,ImgPath = "assets/img/shop_09.jpg",Description = "text"},
                
            };
            
            base.OnModelCreating(builder);
            builder.Entity<Product>().HasData(products);
            

        }
    }
}