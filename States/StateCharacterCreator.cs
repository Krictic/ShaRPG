using Newtonsoft.Json;
using ShaRPG.Gameplay;
using ShaRPG.Gameplay.JobClasses;
using ShaRPG.GUI;
using System.Collections;

namespace ShaRPG.States
{
    internal class StateCharacterCreator
        : State
    {
        // Variables
        readonly ArrayList characterList;

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
                JobProcessing(name, biography, warrior);
            }
            else if (jobName.ToLower() == "archer" || jobName.ToLower() == "a" || jobName.ToLower() == "2")
            {
                Archer archer = new();
                JobProcessing(name, biography, archer);
            }
            else
            {
                Gui.Alert("Invalid job selection!");
                return;
            }

            Gui.Announcement("Character created!");
        }


        // Todo: Simplify this method.
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
                JobProcessing(name, biography, warrior);
            }
            else if (jobName.ToLower() == "archer" || jobName.ToLower() == "a" || jobName.ToLower() == "2")
            {
                Archer archer = new();
                JobProcessing(name, biography, archer);
            }
            else
            {
                Gui.Alert("Invalid job name!");
                return;
            }

            Gui.Announcement("Character created!");
        }
        
        private void JobProcessing(string? name, string? biography, BaseJob job)
        {
            Character character = CharacterObject(name, biography);
            // apply job bonuses to the character
            job.ApplyBonuses(character);
            character.CalculateStats();
            character.StatPoints = Character.StatPointsCalculate(character.Level);
            this.characterList.Add(character);
            character.CalculateExp();
            Guid uuid = Guid.NewGuid();
            charaID(character, uuid);
        }

        private static void charaID(Character character, Guid uuid)
        {
            character.ID = uuid;

            Dictionary<object, object> charDict = new Dictionary<object, object>();

            foreach (var property in character.GetType().GetProperties())
            {
                Console.WriteLine(string.Format("{0}: {1}", property.Name, property.GetValue(character, null)));
                charDict.Add(property.Name, property.GetValue(character));
            }

            string json = JsonConvert.SerializeObject(charDict, Newtonsoft.Json.Formatting.Indented);
            File.AppendAllText("dict.json", json + Environment.NewLine);
        }

        // I know, its disgusting, i am disgusted with myself, but I could see no other way of makign this and not be an illegible mess.
        private static Character CharacterObject(string? name, string? biography)
        {

            bool nameNull = false;
            bool biographyNull = false;

            // This is just to abstract the null checking away to make the if statements easier to understand
            if (name == null)
            {
                nameNull = true;
            }
            if (biography == null)
            {
                biographyNull = true;
            }

            // This is because Character´s parameters are optional
            if (!nameNull && biographyNull)
            {
                return new Character(name);
            }
            else if (nameNull && !biographyNull)
            {
                return new Character(biography);
            }
            else if (nameNull && biographyNull)
            {
                return new Character();
            }
            else
            {
                return new Character(name, biography);
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
                case "E":
                    Console.Clear();
                    this.end = true;
                    break;
                case "1":
                case "N":
                    Console.Clear();
                    this.CreateCharacter();
                    break;
                case "2":
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