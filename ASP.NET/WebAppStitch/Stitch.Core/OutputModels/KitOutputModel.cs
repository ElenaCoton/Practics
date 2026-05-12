using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stitch.Core.OutputModels
{
    public class KitOutputModel
    {
        public int Id { get; set; }

        [DisplayName("Название набора")]
        public string Name { get; set; }

        [DisplayName("Номер набора")]
        public string? KitNumber { get; set; }

        public int? ManufactureId { get; set; }
        [DisplayName("Производитель")]
        public string? ManufacturerName { get; set; }

        // public int? CanvasId { get; set; }
        [DisplayName("Канва")]
        public string? CanvasName { get; set; }

        // public int? NeedleworkId { get; set; }
        [DisplayName("Техника")]
        public string? NeedleworkName { get; set; }

        // public int StatusId { get; set; }
        [DisplayName("Статус")]
        public string? StatusName { get; set; }

        //  public List<ThemeDto>? Themes { get; set; } = new List<ThemeDto>();

        [DisplayName("Сложность")]
        public string? ComplexityName { get; set; }

        [DisplayName("Количество цветов")]
        public int? ColorNumber { get; set; }

        [DisplayName("По горизонтали")]
        public double? XCount { get; set; }

        [DisplayName("По вертикали")]
        public double? YCount { get; set; }

        [DisplayName("Количество крестиков")]
        public double? XYCountCrossStitch { get; set; }

        [DisplayName("Количество")]
        public int? Quantity { get; set; }

        public DateOnly? EndDate { get; set; }

        [DisplayName("Ящик")]
        public string? StoragePlace { get; set; }
        
        [DisplayName("Картинка")]
        public string? ImageLink { get; set; }

        [DisplayName("Описание")]
        public string? Description { get; set; }
    }
}
