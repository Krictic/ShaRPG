using ShaRPG.Gameplay;
using ShaRPG.GUI;
namespace ShaRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            Gui.Title("Welcome");
            game.Run();
        }
    }
}