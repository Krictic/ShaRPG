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
            this.character = activeCharacter;
        }

        public void GenerateMonster(int lvl)
        {
            Monster randomMonster = new Monster("", "");
            randomMonster.DistributeVariables(lvl);
            Console.WriteLine(randomMonster.ToStringDetailed());
        }

        public void ProcessInput(string input)
        {
            switch (input)
            {
                case "-1":
                    Console.Clear();
                    Console.SetCursorPosition(0, Console.CursorTop);
                    this.end = true;
                    break;
                case "1":
                    Console.Clear();
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.WriteLine(this.character.ToString());
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "C":
                    Console.Clear();
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.WriteLine(this.character.ToString());
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "2":
                    Console.Clear();
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.WriteLine(this.character.ToStringDetailed());
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "D":
                    Console.Clear();
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.WriteLine(this.character.ToStringDetailed());
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "3":
                    Console.Clear();
                    Console.SetCursorPosition(0, Console.CursorTop);
                    if (this.character.StatPoints == 0)
                    {
                        Console.WriteLine("You dont have stat points to spend!");
                    } else
                    {
                        this.character.AddStats();
                        this.character.CalculateStats();
                    }
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "A":
                    Console.Clear();
                    Console.SetCursorPosition(0, Console.CursorTop);
                    if (this.character.StatPoints == 0)
                    {
                        Console.WriteLine("You dont have stat points to spend!");
                    }
                    else
                    {
                        this.character.AddStats();
                        this.character.CalculateStats();
                    }
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "4":
                    Console.Clear();
                    Console.SetCursorPosition(0, Console.CursorTop);
                    GenerateMonster(this.character.Level);
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "G":
                    Console.Clear();
                    Console.SetCursorPosition(0, Console.CursorTop);
                    GenerateMonster(this.character.Level);
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
            Gui.MenuOption(4, "(G)enerate a Random Monster");
            Gui.MenuOption(-1, "(E)xit");

            string input = Gui.GetInputInt("").ToUpper().Trim();

            this.ProcessInput(input);
        }
    }
}
