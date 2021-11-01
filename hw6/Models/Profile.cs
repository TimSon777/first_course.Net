using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using hw6.Enums;

namespace hw6.Models
{
    public class Profile
    {
        [Required(ErrorMessage = "Это обязательное поле!")]
        [MaxLength(20, ErrorMessage = "Ограничьте входные данные 20 символами")]
        [DisplayName("Имя")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Это обязательное поле!")]
        [MaxLength(30, ErrorMessage = "Ограничьте входные данные 30 символами")]
        [DisplayName("Фамилия")]
        public string SecondName { get; set; }
        
        [MaxLength(25, ErrorMessage = "Ограничьте входные данные 25 символами")]
        [DisplayName("Отчество")]
        public string Patronymic { get; set; }
        
        [Required(ErrorMessage = "Это обязательное поле!")]
        [Range(14, 120, ErrorMessage = "Вам должно быть больше 14 и меньше 120 лет, чтобы пользоваться сайтом!!!")]
        [DisplayName("Возраст")]
        public int Age { get; set; }
        
        [Required(ErrorMessage = "Это обязательное поле!")]
        [DisplayName("Пол")]
        public Sex Sex { get; set; }
    }
}