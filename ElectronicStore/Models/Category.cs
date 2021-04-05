using System;
using System.Collections.Generic;

namespace ElectronicStore.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; private set; } =DateTime.Now;
        public DateTime ChangeDate { get; set; }
        
        public virtual List<Subcategory> Subcategory { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}