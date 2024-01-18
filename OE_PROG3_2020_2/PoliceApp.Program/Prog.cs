// <copyright file="Prog.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.Program
{
    using System;
    using PoliceApp.Program.MenuItems;

    /// <summary>
    /// Prog class.
    /// </summary>
    public class Prog
    {
        /// <summary>
        /// Main method to implemet the program.
        /// </summary>
        private static void Main()
        {
            MainMenu mainMenu = new MainMenu();
            while (true)
            {
                mainMenu.MainMenuFunction();
                Console.Clear();
            }
        }
    }
}
