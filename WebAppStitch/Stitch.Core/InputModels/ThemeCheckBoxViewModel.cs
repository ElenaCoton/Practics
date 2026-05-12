using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stitch.Core.InputModels
{
    public class ThemeCheckBoxViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsSelected { get; set; } // Для чекбокса

    }
}
