namespace ShaRPG.GUI
{
    internal class Gui
    {
        public static void Title(String str)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            str = string.Format("==== {0} ====\n", str);
            Console.Write(str);
            Console.ResetColor();
        }

        public static void MenuTitle(String str)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            str = string.Format("=== {0} ===\n", str);
            Console.Write(str);
            Console.ResetColor();
        }
        public static void MenuOption(int index, String str)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            str = string.Format(" - ({0}) : {1}\n", index, str);
            Console.Write(str);
            Console.ResetColor();
        }

        public static void Announcement(string str)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            str = string.Format("(~) ({0}) \n", str);
            Console.Write(str);
            Console.ResetColor();
        }

        public static void Alert(string str)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            str = string.Format("\t(!!!) ({0}) \n", str);
            Console.Write(str);
            Console.ResetColor();
        }

        public static string ProgressBar(int min, int max, int width)
        {
            string bar = "[";
            double percent = ((double)min / max);
            int complete = Convert.ToInt32(percent * width);


            for (int i = 0; i < complete; i++)
            {
                bar += "/";
            }

            for (int i = complete; i < width; i++)
            {
                bar += "-";
            }

            bar += "]";

            return bar;
        } 

        public static void GetInput(String str)
        {
            str = string.Format("{0} -> ", str);
            Console.Write(str);
        }


        // Todo: Rewrite the function to handle valid string input as well.
        public static string GetInputInt(string message)
        {
            string? input = null;

            while (input == null)
            {
                try
                {
                    GetInput(message);
                    input = (string?)Console.ReadLine();
                } 
                catch (Exception e) // Error
                {
                    Console.WriteLine(e.Message);
                }
            }

            return input;
        }
    }
}
