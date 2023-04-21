using ShaRPG.Gameplay;
using ShaRPG.Gameplay.JobClasses;
using ShaRPG.GUI;
using System.Collections;
using System.Threading;

namespace ShaRPG.States
{
    internal class StateCharacterCreator
        : State
    {
        // Variables
        ArrayList characterList;

        // Private fuctions
        // Todo: Fix unhandled format exception on this function.
        private void CreateCharacter()
        {
            string name;
            string biography;
            string jobName;

            Gui.GetInput("Name");
            name = Console.ReadLine();
            Gui.GetInput("Write a biography for your character");
            biography = Console.ReadLine().ToLower().Trim();
            Gui.GetInput("What is your character´s job? (You can choose either (1)(W)arrior or (2)(A)rcher)");
            jobName = Console.ReadLine().ToLower().Trim();

            // instantiate the appropriate job class based on user input
            if (jobName.ToLower() == "warrior" || jobName.ToLower() == "w" || jobName.ToLower() == "1")
            {
                Warrior warrior = new();
                jobProcessing(name, biography, warrior);
            }
            else if (jobName.ToLower() == "archer" || jobName.ToLower() == "a" || jobName.ToLower() == "2")
            {
                Archer archer = new();
                jobProcessing(name, biography, archer);
            }
            else
            {
                Gui.Alert("Invalid job selection!");
                return;
            }

            Gui.Announcement("Character created!");
        }
        
        public void CreateStandardCharacter(string jobType)
        {
            string name = "Chadicus";
            string biography = "Maximus";
            string jobName = jobType;

            // instantiate the appropriate job class based on user input
            // instantiate the appropriate job class based on user input
            if (jobName.ToLower() == "warrior" || jobName.ToLower() == "w" || jobName.ToLower() == "1")
            {
                Warrior warrior = new();
                jobProcessing(name, biography, warrior);
            }
            else if (jobName.ToLower() == "archer" || jobName.ToLower() == "a" || jobName.ToLower() == "2")
            {
                Archer archer = new();
                jobProcessing(name, biography, archer);
            }
            else
            {
                Gui.Alert("Invalid job name!");
                return;
            }

            Gui.Announcement("Character created!");
        }
        private void jobProcessing(string name, string biography, BaseJob job)
        {
            // create the character with the given name and biography
            var character = new Character(name, biography);
            // apply job bonuses to the character
            job.ApplyBonuses(character);
            character.CalculateStats();
            this.characterList.Add(character);

            foreach (var property in character.GetType().GetProperties())
            {
                Console.WriteLine(string.Format("{0}: {1}", property.Name, property.GetValue(character, null)));
            }
        }

        public StateCharacterCreator(Stack<State> states, ArrayList character_list)
            : base(states)
        {
            this.characterList = character_list;
        }

        public void ProcessInput(string input)
        {
            switch (input)
            {
                case "-1":
                    Console.Clear();
                    this.end = true;
                    break;
                case "E":
                    Console.Clear();
                    this.end = true;
                    break;
                case "1":
                    Console.Clear();
                    this.CreateCharacter();
                    break;
                case "N":
                    Console.Clear();
                    this.CreateCharacter();
                    break;
                case "2":
                    Console.Clear();
                    this.CreateStandardCharacter("warrior");
                    break;
                case "G":
                    Console.Clear();
                    this.CreateStandardCharacter("warrior");
                    break;
                default:
                    break;
            }
        }

        override public void Update()
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            Gui.MenuTitle("Character Creator");
            Gui.MenuOption(1, "(N)ew Character");
            Gui.MenuOption(2, "(G)enerate Predefined Character");
            Gui.MenuOption(3, "(E)dit Character (Not Yet Implemented)");
            Gui.MenuOption(4, "(D)elete Character (Not Yet Implemented)");
            Gui.MenuOption(-1, "(E)xit");

            string input = Gui.GetInputInt("input").ToUpper().Trim();

            this.ProcessInput(input);
        }
    }
}
