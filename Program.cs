using ShaRPG.Gameplay;
using ShaRPG.GUI;

namespace ShaRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            Game game = new();
            Gui.Title("Welcome to ShaRPG!");
            game.Run();
        }
    }
}