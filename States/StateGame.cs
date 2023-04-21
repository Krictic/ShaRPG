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

        public void GenerateMonster()
        {
            Character character = this.character;
            Monsters randomMonster = new Monsters();
            randomMonster.DistributeVariables(character.Level);

            Gui.Alert($"A {randomMonster.Name} has appeared!");
            foreach (var property in randomMonster.GetType().GetProperties())
            {
                Console.WriteLine("{0}: {1}", property.Name, property.GetValue(randomMonster, null));
            }
        }

        public void ProcessInput(int input)
        {
            switch (input)
            {
                case -1:
                    Console.Clear();
                    Console.SetCursorPosition(0, Console.CursorTop);
                    this.end = true;
                    break;
                case 1:
                    Console.Clear();
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.WriteLine(this.character.ToString());
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 2:
                    Console.Clear();
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.WriteLine(this.character.ToStringDetailed());
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 3:
                    Console.Clear();
                    Console.SetCursorPosition(0, Console.CursorTop);
                    this.character.AddStats();
                    this.character.CalculateStats();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 4:
                    Console.Clear();
                    Console.SetCursorPosition(0, Console.CursorTop);
                    GenerateMonster();
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
            Gui.MenuOption(1, "Character Stats");
            Gui.MenuOption(2, "Character Stats (detailed)");
            Gui.MenuOption(3, "Apply Stat Points");
            Gui.MenuOption(4, "Generate a Random Monster");
            Gui.MenuOption(-1, "Exit");

            int input = Gui.GetInputInt("");

            this.ProcessInput(input);
        }
    }
}
