using ShaRPG.Gameplay;
using ShaRPG.GUI;

namespace ShaRPG.States
{
    internal class StateGame 
        : State
    {

        protected Character character;

        public StateGame(Stack<State> stack, Character activeCharacter) 
            : base(stack) 
        {
            character = activeCharacter;
        }

        public static void GenerateMonster(int lvl)
        {
            CreatureCreator randomMonster = new();
            string creatureChoice = Gui.GetInputInt("What kind of creature you want");

            randomMonster.DistributeVariables(lvl, creatureChoice);
            Console.WriteLine(randomMonster.ToStringDetailed());
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
                    Console.WriteLine(character.ToStringDetailed());
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "3":
                case "A":
                    Console.Clear();
                    Console.SetCursorPosition(0, Console.CursorTop);
                    if (character.StatPoints == 0)
                    {
                        Console.WriteLine("You dont have stat points to spend!");
                    }
                    else
                    {
                        character.AddStats();
                        CharacterCreator.CalculateCharStats(character);
                    }
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "4":
                case "G":
                    Console.Clear();
                    Console.SetCursorPosition(0, Console.CursorTop);
                    GenerateMonster(character.Level);
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
            Gui.MenuOption(2, "(D)etailed Character Stats");
            Gui.MenuOption(3, "(A)pply Stat Points");
            Gui.MenuOption(4, "(G)enerate a Random CreatureCreator");
            Gui.MenuOption(-1, "(E)xit");

            string input = Gui.GetInputInt("").ToUpper().Trim();

            ProcessInput(input);
        }
    }
}
