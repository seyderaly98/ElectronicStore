using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicStore.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; private set; } = DateTime.Now;
        public DateTime ChangeDate { get; set; }
        
        /// <summary>
        /// Всего поставлено
        /// </summary>
        public int TotalDelivered { get; set; }
        
        /// <summary>
        /// Продано Всего
        /// </summary>
        public int Sold { get; set; }
        
        /// <summary>
        /// Дата поставки 
        /// </summary>
        public DateTime DeliveryDate { get; set; } = DateTime.Now;
        
        /// <summary>
        /// Осталось всего
        /// </summary>
        [NotMapped]
        public int Quantity => TotalDelivered - Sold;
        
        /// <summary>
        /// Добавлено в корзину
        /// </summary>
        public int AddedToCart { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ImgPath { get; set; }
        public string Specification { get; set; }
        public string Brand { get; set; }

        public int SubcategoryId { get; set; }
        public virtual Subcategory Subcategory { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public string AuthorId { get; set; }
        public virtual User User { get; set; }
        public virtual List<Shop> Shop { get; set; }
    }
}