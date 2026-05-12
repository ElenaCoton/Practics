using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stitch.Core.OutputModels
{
    public class CanvasOutputModel
    {
        public int Id { get; set; }

        [DisplayName("Название")]
        public string Name { get; set; }

        [DisplayName("Примечание")]
        public string Description { get; set; }
    }
}
