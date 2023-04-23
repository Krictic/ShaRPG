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

        public void ProcessInput(string input)
        {
            switch(input)
            {
                case "-1":
                    this.end = true;
                    break;
                case "E":
                    this.end = true;
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
                    this.StartNewGame();
                    break;
                case "N":
                    this.StartNewGame();
                    break;
                case "2":
                    Gui.Alert("Not implemented yet!");
                    break;
                case "l":
                    Gui.Alert("Not implemented yet!");
                    break;
                case "3":
                    Console.Clear();
                    this.states.Push(new StateCharacterCreator(this.states, this.characterList));
                    break;
                case "C":
                    Console.Clear();
                    this.states.Push(new StateCharacterCreator(this.states, this.characterList));
                    break;
                case "4":
                    Console.Clear();
                    this.SelectCharacter();
                    break;
                case "S":
                    Console.Clear();
                    this.SelectCharacter();
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
            if (this.activeCharacter != null)
            {
                Console.WriteLine(String.Format("{0}\n", this.activeCharacter.ToStringBanner()));
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

            this.ProcessInput(input);
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

            string choice = Gui.GetInputInt("Character Selection");

            try
            {
                this.activeCharacter = (Character?)characterList[Convert.ToInt32(choice)];
            }
            catch (Exception e)
            {
                Gui.Alert(e.Message);
            }

            if (activeCharacter != null)
            {
                Gui.Announcement(String.Format("The character {0} was selected!", this.activeCharacter.GetName()));
            }

            Console.ReadKey();
            Console.Clear();
        }
    }
}
