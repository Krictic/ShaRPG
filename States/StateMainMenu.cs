﻿using ShaRPG.Gameplay;
using ShaRPG.GUI;
using System.Collections;

namespace ShaRPG.States
{
    internal class StateMainMenu
        : State
    {

        protected ArrayList characterList; // characterList is a global variable
        public Character? activeCharacter;
        public bool debugMode = false;

        public StateMainMenu(Stack<State> states, ArrayList character_list)
            : base(states)
        {
            characterList = character_list; // character_list is a local variable
            activeCharacter = null;
        }

        public void ProcessInput(string input)
        {
            switch(input)
            {
                case "-1":
                    end = true;
                    break;
                case "E":
                    end = true;
                    break;
                case "-2":
                    if (!debugMode)
                    {
                        Console.Clear();
                        debugMode = true;
                    }
                    else
                    {
                        Console.Clear();
                        debugMode = false;
                    }
                    Update();
                    break;
                case "D":
                    Console.Clear();
                    if (debugMode)
                    {
                        debugMode = false;
                    }
                    else
                    {
                        debugMode = true;
                    }
                    Update();
                    break;
                case "1":
                case "N":
                    StartNewGame();
                    break;
                case "2":
                case "l":
                    Gui.Alert("Not implemented yet!");
                    break;
                case "3":
                case "C":
                    Console.Clear();
                    states.Push(new StateCharacterCreator(states, characterList));
                    break;
                case "4":
                case "S":
                    Console.Clear();
                    SelectCharacter();
                    break;
                default:
                    Console.Clear();
                    Update();
                    break;
            }
        }

        override public void Update()
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            if (activeCharacter != null)
            {
                Console.WriteLine(string.Format("{0}\n", activeCharacter.ToStringBanner()));
            }
            if (debugMode == true)
            {
                Gui.Announcement("Debug Mode Enabled.");
            }
            Gui.MenuTitle("Main Menu");
            Gui.MenuOption(1, "(N)ew game");
            Gui.MenuOption(2, "(L)oad Game");
            Gui.MenuOption(3, "(C)haracter Creator");
            Gui.MenuOption(4, "(S)elect Characters");
            if (debugMode)
            {
                Gui.MenuOption(-2, "Disable (D)ebug Mode");

            }
            else
            {
                Gui.MenuOption(-2, "Enable (D)ebug Mode");
            }
            Gui.MenuOption(-1, "(E)xit");

            string input = Convert.ToString(Gui.GetInputInt("")).ToUpper().Trim();

            ProcessInput(input);
        }

        public void StartNewGame()
        {
            // While the activeCharacter has a null value, the game cannot start.
            if(activeCharacter == null) // Error
            {
                Gui.Alert("You havent selected a character, please select one at Main Menu -> (3) -> (1) or (2).");
            }
            else if (activeCharacter != null || debugMode == true) // Start game
            {
                states.Push(new StateGame(states, activeCharacter));
            }
        }

        public void SelectCharacter()
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            // Print all characters
            for (int i = 0; i < characterList.Count; i++)
            {
                Console.WriteLine(string.Format("\n{0}:\n{1}", i, characterList[i].ToString()));
            }

            string choice = Gui.GetInputInt("Character Selection");

            try
            {
                activeCharacter = (Character?)characterList[Convert.ToInt32(choice)];
            }
            catch (Exception e)
            {
                Gui.Alert(e.Message);
            }

            if (activeCharacter != null)
            {
                Gui.Announcement(string.Format("The character {0} was selected!", activeCharacter.Name));
            }

            Console.ReadKey();
            Console.Clear();
        }
    }
}
