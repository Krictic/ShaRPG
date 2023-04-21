using ShaRPG.Gameplay;
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
            this.characterList = character_list; // character_list is a local variable
            this.activeCharacter = null;
        }

        public void ProcessInput(int input)
        {
            switch(input)
            {
                case -1:
                    this.end = true;
                    break;
                case -2:
                    if (!debugMode)
                    {
                        debugMode = true;
                    }
                    else
                    {
                        debugMode = false;
                    }
                    break;
                case 1:
                    this.StartNewGame();
                    break;
                case 2:
                    Gui.Alert("Not implemented yet!");
                    break;
                case 3:
                    Console.Clear();
                    this.states.Push(new StateCharacterCreator(this.states, this.characterList));
                    break;
                case 4:
                    Console.Clear();
                    this.SelectCharacter();
                    break;
                case 5:
                    Console.Clear();
                    this.StartNewGame();
                    break;
                default:
                    break;
            }
        }

        override public void Update()
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            if (this.activeCharacter != null)
            {
                Console.WriteLine(String.Format("{0}\n", this.activeCharacter.ToStringBanner()));
            }
            if (debugMode == true)
            {
                Gui.Announcement("Debug Mode Enabled.");
            }
            Gui.MenuTitle("Main Menu");
            Gui.MenuOption(1, "New game");
            Gui.MenuOption(2, "Load Game");
            Gui.MenuOption(3, "Character Creator");
            Gui.MenuOption(4, "Select Characters");
            if (debugMode)
            {
                Gui.MenuOption(5, "Generate a Random Monster");
                Gui.MenuOption(-2, "Disable Debug Mode");

            }
            else
            {
                Gui.MenuOption(-2, "Enable Debug Mode");
            }
            Gui.MenuOption(-1, "Exit");

            int input = Gui.GetInputInt("");

            this.ProcessInput(input);
        }

        public void StartNewGame()
        {
            // While the activeCharacter has a null value, the game cannot start.
            if(activeCharacter == null) // Error
            {
                Gui.Alert("You havent selected a character, please select one at Main Menu -> (3).");
            }
            else if (activeCharacter != null || debugMode == true) // Start game
            {
                this.states.Push(new StateGame(this.states, this.activeCharacter));
            }
        }

        public void SelectCharacter()
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            // Print all characters
            for (int i = 0; i < this.characterList.Count; i++)
            {
                Console.WriteLine(String.Format("\n{0}:\n{1}", i, characterList[i].ToString()));
            }

            int choice = Gui.GetInputInt("Character Selection");

            try
            {
                this.activeCharacter = (Character?)characterList[choice];
            }
            catch (Exception e)
            {
                Gui.Alert(e.Message);
            }

            if (activeCharacter != null)
            {
                Gui.Announcement(String.Format("The character {0} was selected!", this.activeCharacter.Name));
            }

            Console.ReadKey();
            Console.Clear();
        }
    }
}
