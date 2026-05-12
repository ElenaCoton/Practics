using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stitch.Core.Dtos
{
    /// <summary>
    /// Тематика
    /// </summary>
    public class ThemeDto
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование тематики
        /// </summary>
        public string Name { get; set; }

        public List<KitDto> Kits { get; set; } = new List<KitDto>();
    }
}
