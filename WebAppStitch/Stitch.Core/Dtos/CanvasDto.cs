using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stitch.Core.Dtos
{
    /// <summary>
    /// Основа набора
    /// </summary>
    public class CanvasDto
    {
        /*
         * Основные термины и виды основ:
            Embroidery fabric/cloth — общая основа для вышивки.
            Canvas — канва (сетчатая ткань).
            Aida cloth — канва «Аида» (с четкими квадратами).
            Evenweave — ткань равномерного переплетения.
            Linen — лён.
            Plastic canvas — пластиковая канва.
            Stramin — страмин.
            Waste canvas — накладная канва (удаляемая). 
         */
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование основы
        /// </summary>
        [DisplayName("Название")]
        public string Name { get; set; }

        public List<KitDto> Kits { get; set; } = new List<KitDto>();
    }
}
