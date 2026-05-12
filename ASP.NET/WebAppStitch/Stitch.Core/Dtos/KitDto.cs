using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stitch.Core.Dtos
{
    /// <summary>
    /// Набор для вышивания
    /// </summary>
    public class KitDto
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название набора
        /// </summary>
        [DisplayName("Название")]
        public string Name { get; set; }

        /// <summary>
        /// Номер набора
        /// </summary>
          [DisplayName("Номер набора")]
        public string? KitNumber { get; set; }

        /// <summary>
        /// Производитель
        /// </summary>
        [DisplayName("Производитель")]
        public int? ManufactureId { get; set; }
        [ForeignKey(nameof(ManufactureId))]
        public ManufacturerDto? Manufacturer { get; set; }

        /// <summary>
        /// Основа
        /// </summary>
        [DisplayName("Канва")]
        public int? CanvasId { get; set; }
        [ForeignKey(nameof(CanvasId))]
        public CanvasDto? Canvas { get; set; }
        
        /// <summary>
        /// Техника
        /// </summary>
        [DisplayName("Техника вышивания")]
        public int? NeedleworkId { get; set; }
        [ForeignKey(nameof(NeedleworkId))]
        public NeedleworkDto? Needlework { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        [DisplayName("Статус")]
        [Required]
        public int? StatusId { get; set; }
        [ForeignKey(nameof(StatusId))]
        public StatusDto? Status { get; set; }

        /// <summary>
        /// Тематика
        /// </summary>
        public List<ThemeDto>? Themes { get; set; } = new List<ThemeDto>();

        /// <summary>
        /// Сложность набора
        /// </summary>
        [DisplayName("Сложность")]
        [Range(1, 5)]
        public int? Complexity { get; set; }

        /// <summary>
        /// Количество цветов
        /// </summary>
        [DisplayName("Количество цветов")]
        public int? ColorNumber { get; set; }

        /// <summary>
        /// Количество крестиков по горизонтали (см)
        /// </summary>
        public double? XCount { get; set; }

        /// <summary>
        /// Количество крестиков по вертикали (см)
        /// </summary>
        public double? YCount { get; set; }

        /// <summary>
        /// Количество наборов 
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// Дата окончания
        /// </summary>
        public DateOnly? EndDate { get; set; }

        /// <summary>
        /// Место хранения
        /// </summary>
        public string? StoragePlace { get; set; }

        /// <summary>
        /// Ссылка на картинку
        /// </summary>
        [DisplayName("Изображение набора")]
        public string? ImageLink { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        [DisplayName("Описание")]
        public string? Description { get; set; }
    }
}
