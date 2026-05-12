using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stitch.Core.OutputModels
{
    public class ManufacturerOutputModel
    {
        public int Id { get; set; }

        [DisplayName("Название")]
        public string Name { get; set; }

        [DisplayName("Количество наборов данного производителя")]
        public int KitsCount { get; set; }
    }
}
