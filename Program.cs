﻿using ShaRPG.Controller;
using ShaRPG.View.GUI;

namespace ShaRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            InitGameController game = new();
            Gui.Title("Welcome to ShaRPG!");
            game.Run();
        }
    }
}