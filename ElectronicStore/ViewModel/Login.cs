using System.ComponentModel.DataAnnotations;

namespace ElectronicStore.ViewModel
{
    public class Login
    {
        [Required(ErrorMessage = "Это поле необходимо заполнить.")]
        [EmailAddress(ErrorMessage = "Пожалуйста, введите действительный адрес электронной почты.")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Это поле необходимо заполнить.")]
        [DataType(DataType.Password)]
        [MinLength(3,ErrorMessage = "Пароль должен содержать не менее 8 символов.")]
        public string Password { get; set; }

        public bool Remember { get; set; }
    }
}