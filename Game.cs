using ShaRPG.States;
using System.Collections;

namespace ShaRPG
{
    internal class Game
    {
        // Member Variables
        private bool end;

        public bool End
        {
            get { return end; }
            set { end = value; }
        }

        private void InitStates()
        {
            states = new Stack<State>();

            // Push the first state 
            states.Push(new StateMainMenu(states, characterList));
        }

        private Stack<State> states;
        private ArrayList characterList;


        // Private Functions
        private void InitVariables()
        {
            end = false;
        }

        private void InitCharacterList()
        {
            characterList = new ArrayList();
        }

        //Constructors and Destructors
        public Game() 
        {
            InitVariables();
            InitCharacterList();
            InitStates();
        }
        public void Run()
        {
            while(states.Count > 0)
            {
                states.Peek().Update();

                if (states.Peek().RequestEnd)
                {
                    states.Pop();

                }
            }
            Console.WriteLine("Ending game.");
        }
    }
}
