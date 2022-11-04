using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;

namespace MenuSystem
{
    public class Menu

    {
        private readonly EMenuLevel _level;

        private const string ShortcutExit = "X";
        private const string ShortcutGoBack = "B";
        private const string ShortcutGoToMain = "M";
        public string Title { get; set; }
        private readonly Dictionary<string, MenuItem> _menuItems = new Dictionary<string, MenuItem>();
        //Dictionary словарик (встроенный класс)

        private readonly MenuItem _menuItemExit = new MenuItem(ShortcutExit, "Exit", null);
        // переменные класса (поля класса) fields
        // _нижнее подчеркивание = приватная переменная для использования внутри этого класса/объекта
        private readonly MenuItem _menuItemGoBack = new MenuItem(ShortcutGoBack, "Back", null);
        private readonly MenuItem _menuItemGoToMain = new MenuItem(ShortcutGoToMain, "Main menu", null);

        public Menu(EMenuLevel level, string title, List<MenuItem> menuItems)
        {
            _level = level;
            Title = title;
            foreach (var menuItem in menuItems)
            {
                _menuItems.Add(menuItem.Shortcut, menuItem);
            }

            if (_level != EMenuLevel.Main)
                _menuItems.Add(ShortcutGoBack, _menuItemGoBack);

            if (_level == EMenuLevel.Other)
                _menuItems.Add(ShortcutGoToMain, _menuItemGoToMain);

            _menuItems.Add(ShortcutExit, _menuItemExit);
        }


        public string RunMenu()
        {
            var menuDone = false;
            var userChoice = "";
            do
            {
                Console.WriteLine(Title);
                Console.WriteLine("===================");
                foreach (var menuItem in _menuItems.Values)
                {
                    Console.WriteLine(menuItem);
                }

                Console.WriteLine("-------------------");
                Console.Write("Your choice:");
                userChoice = Console.ReadLine()?.ToUpper().Trim() ?? "";

                if (_menuItems.ContainsKey(userChoice))
                {
                    string? runReturnValue = null;
                    if (_menuItems[userChoice].MethodToRun != null)
                    {
                        runReturnValue = _menuItems[userChoice].MethodToRun!();
                    }

                    if (userChoice == ShortcutGoBack)
                    {
                        menuDone = true;
                    }

                    if (
                        runReturnValue == ShortcutExit ||
                        userChoice == ShortcutExit
                    )
                    {
                        userChoice = runReturnValue ?? userChoice;
                        menuDone = true;
                    }


                    if ((userChoice == ShortcutGoToMain || runReturnValue == ShortcutGoToMain) && _level != EMenuLevel.Main)
                    {
                        userChoice = runReturnValue ?? userChoice;
                        menuDone = true;
                    }

                }
                else
                {
                    //ошибка
                    Console.WriteLine("Something goes wrong, try again please!");
                    Console.WriteLine("=!=!=!=!=!=!=!=");
                }
            }
            //повтор меню
            while (menuDone == false);

            return userChoice;
        }
    }
}
