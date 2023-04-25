using ShaRPG.Controller.States;
using ShaRPG.Model;
using System.Collections;

namespace ShaRPG.Controller
{
    internal class InitGameController
    {
        Model.InitGameModel gameModel = new Model.InitGameModel();
        private void InitStates()
        {
            Stack<State> states = gameModel.GetStates();
            ArrayList characterList = gameModel.GetCharacterList();

            // Push the first state 
            states.Push(new StateMainMenu(states, characterList));
        }

        // Private Functions
        private void InitVariables()
        {
            gameModel.SetEnd(false);
        }

        private void InitCharacterList()
        {
            ArrayList characterList = gameModel.GetCharacterList();
            gameModel.SetCharacterList(characterList);
        }

        //Constructors and Destructors0
        public InitGameController()
        {
            InitVariables();
            InitCharacterList();
            InitStates();
        }
        public void Run()
        {
            while (gameModel.GetStates().Count > 0)
            {
                gameModel.GetStates().Peek().Update();

                if (gameModel.GetStates().Peek().RequestEnd)
                {
                    gameModel.GetStates().Pop();

                }
            }
            Console.WriteLine("Ending game.");
        }
    }
}
