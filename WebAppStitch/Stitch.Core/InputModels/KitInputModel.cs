using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stitch.Core.Dtos;

namespace Stitch.Core.InputModels
{
    public class KitInputModel
    {
        public int Id { get; set; }

        [DisplayName("Название")]
        public string Name { get; set; }

        [DisplayName("Номер набора")]
        public string? KitNumber { get; set; }

        [DisplayName("Производитель")]
        public int? ManufactureId { get; set; }

        [DisplayName("Канва")]
        public int? CanvasId { get; set; }

        [DisplayName("Техника вышивания")]
        public int? NeedleworkId { get; set; }

        [DisplayName("Статус")]
        [Required]
        public int? StatusId { get; set; }

        [DisplayName("Сложность")]
        [Range(1, 5)]
        public int? Complexity { get; set; }

        [DisplayName("Количество цветов")]
        public int? ColorNumber { get; set; }

        [DisplayName("По горизонтали (см)")]
        public double? XCount { get; set; }

        [DisplayName("По вертикали (см)")]
        public double? YCount { get; set; }

        [DisplayName("Количество наборов")]
        public int? Quantity { get; set; }

        [DisplayName("Дата окончания")]
        public DateOnly? EndDate { get; set; }

        [DisplayName("Место хранения")]
        public string? StoragePlace { get; set; }

        [DisplayName("Изображение набора")]
        public string? ImageLink { get; set; }

        [DisplayName("Описание")]
        public string? Description { get; set; }

        /// <summary>
        /// Тематика
        /// </summary>
        public List<ThemeDto>? Themes { get; set; } = new List<ThemeDto>();
        // Список всех доступных тегов (для отображения)
        public List<CheckBoxItem> AllTags { get; set; }
        // Список всех доступных курсов с состоянием "выбран"
        public List<ThemeCheckBoxViewModel> ThemeCheckBoxes { get; set; }
    }
}
