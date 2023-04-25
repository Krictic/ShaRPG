using ShaRPG.Model;
using ShaRPG.Model.Creators;
using ShaRPG.View.GUI;

namespace ShaRPG.Controller.States
{
    internal class StateGame
        : State
    {

        protected CharacterModel character;

        public StateGame(Stack<State> stack, CharacterModel activeCharacter)
            : base(stack)
        {
            character = activeCharacter;
        }

        public static void GenerateMonster(int lvl)
        {
            Random rng = new Random();
            CreatureModel randomMonster = new();
            //string creatureChoice = Gui.GetInputInt("What kind of creature you want");

            string creatureJob;
            int variableIndex = rng.Next(3);

            switch (variableIndex)
            {
                case 0:
                    creatureJob = "rat";
                    break;
                case 1:
                    creatureJob = "goblin";
                    break;
            }

            randomMonster.DistributeVariables(lvl, creatureJob);
            Console.WriteLine(CreatureModel.ToStringDetailed(randomMonster));
        }

        public void ProcessInput(string input)
        {
            switch (input)
            {
                case "-1":
                    Console.Clear();
                    Console.SetCursorPosition(0, Console.CursorTop);
                    end = true;
                    break;
                case "1":
                case "C":
                    Console.Clear();
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.WriteLine(character.ToString());
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "2":
                case "D":
                    Console.Clear();
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.WriteLine(View.StringViewCharacter.ToStringDetailed(character));
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "3":
                case "A":
                    Console.Clear();
                    Console.SetCursorPosition(0, Console.CursorTop);
                    if (character.GetStatPoints() == 0)
                    {
                        Console.WriteLine("You dont have stat points to spend!");
                    }
                    else
                    {
                        character.AddStats(character);
                        CharacterCreator.CalculateCharStats(character);
                    }
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "4":
                case "G":
                    Console.Clear();
                    Console.SetCursorPosition(0, Console.CursorTop);
                    GenerateMonster(character.GetLevel());
                    Console.ReadKey();
                    Console.Clear();
                    break;
                default:
                    break;
            }
        }

        override public void Update()
        {
            Console.Clear();
            Console.SetCursorPosition(0, Console.CursorTop);
            Gui.MenuTitle("GameState");
            Gui.MenuOption(1, "(C)haracter Stats");
            Gui.MenuOption(2, "(D)etailed CharacterModel Stats");
            Gui.MenuOption(3, "(A)pply Stat Points");
            Gui.MenuOption(4, "(G)enerate a Random CreatureModel");
            Gui.MenuOption(-1, "(E)xit");

            string input = Gui.GetInputInt("").ToUpper().Trim();

            ProcessInput(input);
        }
    }
}
