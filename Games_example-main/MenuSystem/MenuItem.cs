using System;

namespace MenuSystem
{

    public class MenuItem
    {
        public string Title { get; set; }
        public string Shortcut { get; set; }
        public Func<string>? MethodToRun { get; set; }
        //переменные (проперти)

        public MenuItem(string shortcut, string title, Func<string>? methodToRun)
        // Action? = функция или метод который надо запускать
        {
            Shortcut = shortcut;
            Title = title;
            MethodToRun = methodToRun;
            //когда создается класс, параметры сохраняются в классе.
        }


        public override string ToString() => Shortcut + ") " + Title;


    }
}