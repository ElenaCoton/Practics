using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stitch.Core.Dtos
{
    /// <summary>
    /// Статус набора (в работе, не начат, окончен)
    /// </summary>
    public class StatusDto
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование статуса
        /// </summary>
        public string Name { get; set; }

        public List<KitDto> Kits { get; set; } = new List<KitDto>();
    }
}
