using ShaRPG.Controller.States;
using ShaRPG.Model;
using System.Collections;

namespace ShaRPG.Controller
{
    internal class InitGame : InitGameModel
    {

        InitGameModel gameModel = new InitGameModel();
        private void InitStates()
        {
            //Stack<State> states = new Stack<State>();
            //ArrayList characterList = new ArrayList();
            Stack<State> states = gameModel.GetStates();
            ArrayList characterList = gameModel.GetCharacterList();
            // Push the first state 
            states.Push(new StateMainMenu(states, characterList));
        }

        //private Stack<State> states;
        //private ArrayList characterList;


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
        public InitGame()
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
