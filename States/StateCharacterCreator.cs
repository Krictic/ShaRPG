using ShaRPG.Gameplay;
using ShaRPG.GUI;
using System.Collections;

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
            biography = Console.ReadLine();
            Gui.GetInput("What is your character´s job? (You can choose either Warrior or Archer)");
            jobName = Console.ReadLine();

            // instantiate the appropriate job class based on user input
            Job.BaseJob job;
            if (jobName.ToLower() == "warrior")
            {
                job = new Job.Warrior();
            }
            else if (jobName.ToLower() == "archer")
            {
                job = new Job.Archer();
            }
            else
            {
                Gui.Alert("Invalid job name!");
                return;
            }

            // create the character with the given name and biography
            var character = new Character(name, biography);

            // apply job bonuses to the character
            job.ApplyBonuses(character);

            character.CalculateStats();

            this.characterList.Add(character);

            Gui.Announcement("Character created!");

            foreach (var property in character.GetType().GetProperties())
            {
                Console.WriteLine("{0}: {1}", property.Name, property.GetValue(character, null));
            }

            Console.WriteLine("Export this character? Y/N");
            string answer = Console.ReadLine().ToLower().Trim();

            if (answer == "y")
            {
                Gui.Alert("Not yet implemented!");
            }
        }

        private void CreateStandardCharacter(string jobType)
        {
            string name = "Chadicus";
            string biography = "Maximus";
            string jobName = jobType;

            // instantiate the appropriate job class based on user input
            Job.BaseJob job;
            if (jobName.ToLower() == "warrior")
            {
                job = new Job.Warrior();
            }
            else if (jobName.ToLower() == "archer")
            {
                job = new Job.Archer();
            }
            else
            {
                Gui.Alert("Invalid job name!");
                return;
            }

            // create the character with the given name and biography
            var character = new Character(name, biography);

            // apply job bonuses to the character
            job.ApplyBonuses(character);

            character.CalculateStats();

            this.characterList.Add(character);

            Gui.Announcement("Character created!");

            foreach (var property in character.GetType().GetProperties())
            {
                Console.WriteLine("{0}: {1}", property.Name, property.GetValue(character, null));
            }

            Console.WriteLine("Export this character? Y/N");
            string answer = Console.ReadLine().ToLower().Trim();

            if (answer == "y")
            {
                Gui.Alert("Not yet implemented!");
            }
        }

        public StateCharacterCreator(Stack<State> states, ArrayList character_list)
            : base(states)
        {
            this.characterList = character_list;
        }

        public void ProcessInput(int input)
        {
            switch (input)
            {
                case -1:
                    Console.Clear();
                    this.end = true;
                    break;
                case 1:
                    Console.Clear();
                    this.CreateCharacter();
                    break;
                case 2:
                    Console.Clear();
                    Gui.GetInput("Type the job you want your character to have (only warrior or archer available for now)");
                    string jobType = Console.ReadLine();
                    this.CreateStandardCharacter(jobType);
                    break;
                default:
                    break;
            }
        }

        override public void Update()
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            Gui.MenuTitle("Character Creator");
            Gui.MenuOption(1, "New Character");
            Gui.MenuOption(2, "Generate Predefined Character");
            Gui.MenuOption(3, "Edit Character (Not Yet Implemented)");
            Gui.MenuOption(4, "Delete Character (Not Yet Implemented)");
            Gui.MenuOption(-1, "Exit");

            int input = Gui.GetInputInt("input");

            this.ProcessInput(input);
        }
    }
}
