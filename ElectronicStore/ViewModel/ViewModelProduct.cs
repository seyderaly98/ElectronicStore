using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ElectronicStore.ViewModel
{
    public class ViewModelProduct
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Это поле необходимо заполнить.")]
        public string Name { get; set; }

        /// <summary>
        /// Всего поставлено
        /// </summary>
        [Required(ErrorMessage = "Это поле необходимо заполнить.")]
        public int TotalDelivered { get; set; }
        [Required(ErrorMessage = "Это поле необходимо заполнить.")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Это поле необходимо заполнить.")]
        public string Description { get; set; }
        public string ImgPath { get; set; }
        [Required(ErrorMessage = "Это поле необходимо заполнить.")]
        public string Specification { get; set; }
        [Required(ErrorMessage = "Это поле необходимо заполнить.")]
        public string Brand { get; set; }
        [Required(ErrorMessage = "Это поле необходимо заполнить.")]
        public int SubcategoryId { get; set; }
        [Required(ErrorMessage = "Это поле необходимо заполнить.")]
        public int CategoryId { get; set; }
        public string AuthorId { get; set; }
        [Required(ErrorMessage = "Это поле необходимо заполнить.")]
        public IFormFile File { get; set; }

    }
}