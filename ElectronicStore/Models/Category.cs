using System;

namespace ElectronicStore.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; private set; } =DateTime.Now;
        public DateTime ChangeDate { get; set; }

        public int SubcategoryId { get; set; }
        public Subcategory Subcategory { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}