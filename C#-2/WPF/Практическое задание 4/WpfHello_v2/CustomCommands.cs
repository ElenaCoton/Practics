using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfHello_v2
{
    public class CustomCommands
    {
        //Команду определить как статическое свойство только для чтения с именем Launch,
        //возвращающую экземпляр RoutedUICommand:
        public static RoutedUICommand Launch { get; }

        //статический конструктор, который
        //a.создает новую коллекцию InputGestureCollection,
        //b. добавляет соответствующую клавишу ввода, связанную с новой командой (Ctrl+L)
        //c.и инициирует переменную, возвращающую настраиваемую команду:
        static CustomCommands()
        {
            InputGestureCollection myInputGestures = new
            InputGestureCollection();
            myInputGestures.Add(new KeyGesture(Key.L, ModifierKeys.Control));
            Launch = new RoutedUICommand("Запуск", "Launch",  typeof(CustomCommands), myInputGestures);
        }
    }
}
