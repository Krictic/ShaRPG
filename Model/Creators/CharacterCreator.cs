using Newtonsoft.Json;
using ShaRPG.Model.JobClasses.CharacterClassess;
using ShaRPG.View.GUI;
using System.Collections;

namespace ShaRPG.Model.Creators
{
    internal class CharacterCreator
    {

        public static ArrayList CreateCharacter(ArrayList characterList)
        {

            Gui.GetInput("Name");
            string name = Console.ReadLine();
            Gui.GetInput("Write a biography for your character");
            string biography = Console.ReadLine().ToLower().Trim();
            Gui.GetInput("What is your character´s Job? (You can choose either (1)(W)arrior or (2)(A)rcher)");
            string jobName = Console.ReadLine().ToLower().Trim();

            // instantiate the appropriate Job class based on user input
            if (jobName.ToLower() == "warrior" || jobName.ToLower() == "w" || jobName.ToLower() == "1")
            {
                Warrior warrior = new();
                characterList = JobProcessing(name, biography, warrior, characterList);
            }
            else if (jobName.ToLower() == "archer" || jobName.ToLower() == "a" || jobName.ToLower() == "2")
            {
                Archer archer = new();
                characterList = JobProcessing(name, biography, archer, characterList);

            }

            return characterList;
        }


        /// <summary>
        /// This will create a character with placeholder name and biography, intended for faster character creation
        /// once i allow for cusstom characters.
        /// </summary>
        /// <param name="jobType"></param>
        public static ArrayList CreateFastCharacter(string jobType, ArrayList characterList)
        {
            string name = "Chadicus";
            string biography = "Maximus";
            string jobName = jobType;

            // instantiate the appropriate Job class based on user input
            if (jobName.ToLower() == "warrior" || jobName.ToLower() == "w" || jobName.ToLower() == "1")
            {
                Warrior warrior = new();
                characterList = JobProcessing(name, biography, warrior, characterList);
            }
            else if (jobName.ToLower() == "archer" || jobName.ToLower() == "a" || jobName.ToLower() == "2")
            {
                Archer archer = new();
                characterList = JobProcessing(name, biography, archer, characterList);
            }

            // God i hope this works.
            return characterList; // This will go to ChracterCreatorController
        }

        /// <summary>
        /// This is used to create a full character instance. This may be used for both player and NPC characters.
        /// </summary>
        /// <param name="name"></param>
        /// Name of the character instance (may be null)
        /// <param name="biography"></param>
        /// Biography (or description) of the CharacterModel instance
        /// <param name="Job"></param>
        /// The Job (RPG classes) to be applied to the CharacterModel instance.
        public static ArrayList JobProcessing(string? name, string? biography, JobTemplate Job, ArrayList characterList)
        {
            CharacterModel character = CharacterNullCheck(name, biography);
            Job.ApplyBonuses(character);
            CalculateCharStats(character);

            // Generate uuid for character
            charaID(character);
            printAndStoreCharacter(character);

            characterList.Add(character);
            return characterList; // This will be returned to CreateFastCharacter
        }

        public static void CalculateCharStats(CharacterModel character)
        {
            // Some shorthands for basic stats
            int st = character.GetStrength();
            int vit = character.GetVitality();
            int dex = character.GetDexterity();
            int agi = character.GetAgility();
            int iq = character.GetIntelligence();

            // Calculate secondary stats
            character.SetDamage(character.CalculateBaseDamage(st));
            character.SetHpMax(character.CalculateHpMax(vit));
            character.SetHp(character.GetHpMax());
            character.SetAccuracy(character.CalculateAccuracy(dex));
            character.SetDefence(character.CalculateDefence(agi));
            character.SetManaMax(character.CalculateManaMax(iq));

            // Calculate tertiary stats
            character.SetCriticalChance(character.CalculateCritChance(dex, character.GetAccuracy()));
            character.SetCriticalDamage(character.CalculateCritDamage(dex, iq, character.GetDamage()));

            // Calculate experience stats
            character.SetStatPoints(CharacterModel.StatPointsCalculate(character.GetLevel()));
            character.SetMaxExperience(character.CalculateExp(character.GetLevel()));
        }

        /// <summary>
        /// This generates a unique id for each CharacterModel isntance, this will be useful later.
        /// </summary>
        /// <param name="character"></param>
        public static void charaID(CharacterModel character)
        {
            Guid uuid = new();
            character.SetID(uuid);
        }

        public static void printAndStoreCharacter(CharacterModel character)
        {
            Dictionary<object, object> charDict = new Dictionary<object, object>();

            foreach (var property in character.GetType().GetProperties())
            {
                Console.WriteLine(string.Format("{0}: {1}", property.Name, property.GetValue(character, null)));
                charDict.Add(property.Name, property.GetValue(character));
            }

            Gui.Announcement($"CharacterModel {character.GetName()} created!");
            string json = JsonConvert.SerializeObject(charDict, Formatting.Indented);
            File.AppendAllText("dict.json", json + Environment.NewLine);
        }

        /// <summary>
        /// This is a null-checking method which allows for null values to be passed as parameters for the CharacterModel class constructor.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="biography"></param>
        /// <returns></returns>
        public static CharacterModel CharacterNullCheck(string? name, string? biography)
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

            // This is because CharacterModel´s parameters are optional
            if (!nameNull && biographyNull)
            {
                return new CharacterModel(name);
            }
            else if (nameNull && !biographyNull)
            {
                return new CharacterModel(biography);
            }
            else if (nameNull && biographyNull)
            {
                return new CharacterModel();
            }
            else
            {
                return new CharacterModel(name, biography);
            }
        }
    }
}

