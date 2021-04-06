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
        /// Продано
        /// </summary>
        Sold,
        None
    }
    
    public class Shop
    {
        public int Id { get; set; }
        
        public ShopStatus Status { get; set; } = ShopStatus.ShoppingСart;
        public DateTime CreateDate { get; private set; } = DateTime.Now;
        public DateTime ChangeDate { get; set; }
        public string Description { get; set; }
        
        public string СlientId { get; set; }
        public virtual User Client { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public Shop()
        {
        }

        public Shop(string сlientId, int productId)
        {
            СlientId = сlientId;
            ProductId = productId;
        }
    }
}