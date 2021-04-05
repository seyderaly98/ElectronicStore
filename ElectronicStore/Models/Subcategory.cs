using System;

namespace ElectronicStore.Models
{
    public class Subcategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; private set; } = DateTime.Now;
        public DateTime ChangeDate { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}