using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stitch.Core.InputModels
{
    public class StudentViewModel
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        // Список всех доступных курсов с состоянием "выбран"
        public List<ThemeCheckBoxViewModel> ThemeCheckBoxes { get; set; }
    }
}
