using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcCreditApp.Models
{
    public class Credit
    {
        // ID кредита
        public virtual int CreditId { get; set; }

        // Название
        [DisplayName("Название")]
        [Required(ErrorMessage = "Поле обязательно")]
        public virtual string Head { get; set; }

        // Период, на который выдается кредит
        [DisplayName("Период кредита")]
        [Required(ErrorMessage = "Поле обязательно")]
        public virtual int Period { get; set; }

        // Максимальная сумма кредита
        [DisplayName("MAX сумма кредита")]
        [Required(ErrorMessage = "Поле обязательно")]
        public virtual int Sum { get; set; }

        // Процентная ставка
        [DisplayName("Процентная ставка")]
        [Required(ErrorMessage = "Поле обязательно")]
        public virtual int Procent { get; set; }
    }
}
