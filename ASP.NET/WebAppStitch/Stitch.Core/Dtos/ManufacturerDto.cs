using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stitch.Core.Dtos
{
    /// <summary>
    /// Производитель
    /// </summary>
    public class ManufacturerDto
    {
        /// <summary>
        /// Уникаьный идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование производителя
        /// </summary>
        public string Name { get; set; }

        public List<KitDto> Kits { get; set; } = new List<KitDto>();
    }
}
