using ShaRPG.Model;
using ShaRPG.View.GUI;
using System.Collections;

namespace ShaRPG.Controller.States
{
    internal class StateCharacterCreator
        : State
    {
        // Variables
        ArrayList characterList;

        public StateCharacterCreator(Stack<State> states, ArrayList character_list)
            : base(states)
        {
            characterList = character_list;
        }
        public void ProcessInput(string input)
        {
            switch (input)
            {
                case "-1":
                case "E":
                    Console.Clear();
                    end = true;
                    break;
                case "1":
                case "N":
                    Console.Clear();
                    characterList = CharacterCreator.CreateCharacter(characterList);
                    break;
                case "2":
                case "G":
                    Console.Clear();
                    randomJobChooser();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// This randomly chooses a Job for the fast character generator.
        /// </summary>
        public void randomJobChooser()
        {
            Random rnd = new Random();
            int variableIndex = rnd.Next(2);
            if (variableIndex == 1)
            {
                characterList = CharacterCreator.CreateFastCharacter("warrior", characterList);
            }
            else
            {
                characterList = CharacterCreator.CreateFastCharacter("archer", characterList);
            }
        }

        override public void Update()
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            Gui.MenuTitle("Character Creator");
            Gui.MenuOption(1, "(N)ew Character");
            Gui.MenuOption(2, "(G)enerate Fast Character");
            Gui.MenuOption(3, "(E)dit Character (Not Yet Implemented)");
            Gui.MenuOption(4, "(D)elete Character (Not Yet Implemented)");
            Gui.MenuOption(-1, "(E)xit");

            string input = Gui.GetInputInt("input").ToUpper().Trim();

            ProcessInput(input);
        }
    }
}