using System;

namespace ElectronicStore.Models
{
    public enum ShopStatus
    {
        /// <summary>
        /// В обработке 
        /// </summary>
        InProcessing,
        
        /// <summary>
        /// Отправлено 
        /// </summary>
        Shipped,
        
        /// <summary>
        /// В корзине 
        /// </summary>
        ShoppingСart,
        
        /// <summary>
        /// Доставлено 
        /// </summary>
        Delivered,
        
    }
    
    public class Shop
    {
        public int Id { get; set; }
        
        public ShopStatus Type { get; set; } = ShopStatus.ShoppingСart;
        public DateTime CreateDate { get; private set; } = DateTime.Now;
        public DateTime ChangeDate { get; set; }
        public string Description { get; set; }
        
        public string СlientId { get; set; }
        public User Client { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        
    }
}