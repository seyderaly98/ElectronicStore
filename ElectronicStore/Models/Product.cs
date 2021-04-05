using System;

namespace ElectronicStore.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; private set; } = DateTime.Now;
        public DateTime ChangeDate { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string ImgPath { get; set; }

        public int SubcategoryId { get; set; }
        public virtual Subcategory Subcategory { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public string AuthorId { get; set; }
        public virtual User User { get; set; }
    }
}