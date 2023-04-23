using Newtonsoft.Json;
using ShaRPG.Gameplay;
using ShaRPG.Gameplay.JobClasses;
using ShaRPG.GUI;
using System;
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


        /// <summary>
        /// This will create a character with placeholder name and biography, intended for faster character creation
        /// once i allow for cusstom characters.
        /// </summary>
        /// <param name="jobType"></param>
        public void CreateFastCharacter(string jobType)
        {
            string name = "Chadicus";
            string biography = "Maximus";
            string jobName = jobType;

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

        /// <summary>
        /// This is used to create a full character instance. This may be used for both player and NPC characters.
        /// </summary>
        /// <param name="name"></param>
        /// Name of the character instance (may be null)
        /// <param name="biography"></param>
        /// Biography (or description) of the Character instance
        /// <param name="job"></param>
        /// The job (RPG classes) to be applied to the Character instance.
        private void JobProcessing(string? name, string? biography, BaseJob job)
        {
            Character character = CharacterObject(name, biography);
            job.ApplyBonuses(character);
            character.CalculateStats();
            character.StatPoints = Character.StatPointsCalculate(character.Level);
            this.characterList.Add(character);
            character.CalculateExp();
            charaID(character);
            printAndStoreCharacter(character);
        }

        /// <summary>
        /// This generates a unique id for each Character isntance, this will be useful later.
        /// </summary>
        /// <param name="character"></param>
        private static void charaID(Character character)
        {
            Guid uuid = new();
            character.ID = uuid;
        }

        private static void printAndStoreCharacter(Character character)
        {
            Dictionary<object, object> charDict = new Dictionary<object, object>();

            foreach (var property in character.GetType().GetProperties())
            {
                Console.WriteLine(string.Format("{0}: {1}", property.Name, property.GetValue(character, null)));
                charDict.Add(property.Name, property.GetValue(character));
            }

            string json = JsonConvert.SerializeObject(charDict, Newtonsoft.Json.Formatting.Indented);
            File.AppendAllText("dict.json", json + Environment.NewLine);
        }

        /// <summary>
        /// This is a null-checking method which allows for null values to be passed as parameters for the Character class constructor.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="biography"></param>
        /// <returns></returns>
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
                    randomJobChooser();
                    break;
                case "G":
                    Console.Clear();
                    randomJobChooser();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// This randomly chooses a job for the fast character generator.
        /// </summary>
        private void randomJobChooser()
        {
            Random rnd = new Random();
            int variableIndex = rnd.Next(1);
            if (variableIndex == 1)
            {
                this.CreateFastCharacter("warrior");
            }
            else
            {
                this.CreateFastCharacter("archer");
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

            this.ProcessInput(input);
        }
    }
}