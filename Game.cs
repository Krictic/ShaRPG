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
            get { return this.End; }
            set { this.End = value; }
        }

        private void InitStates()
        {
            this.states = new Stack<State>();

            // Push the first state 
            this.states.Push(new StateMainMenu(this.states, this.characterList));
        }

        private Stack<State> states;
        private ArrayList characterList;


        // Private Functions
        private void initVariables()
        {
            this.end = false;
        }

        private void InitCharacterList()
        {
            this.characterList = new ArrayList();
        }

        //Constructors and Destructors
        public Game() 
        {
            this.initVariables();
            this.InitCharacterList();
            this.InitStates();
        }
        public void Run()
        {
            while(this.states.Count > 0)
            {
                this.states.Peek().Update();

                if (this.states.Peek().RequestEnd())
                {
                    this.states.Pop();

                }
            }
            Console.WriteLine("Ending game.");
        }
    }
}
