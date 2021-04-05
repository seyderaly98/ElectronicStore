using System;

namespace ElectronicStore.Models
{
    public class CategoriesMonth
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; private set; } =DateTime.Now;
        public DateTime ChangeDate { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public string AuthorId { get; set; }
        public User Author { get; set; }
    }
}