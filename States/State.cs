namespace ShaRPG.States
{
    internal class State
    {
        protected Stack<State> states;
        protected bool end = false;

        public Stack<State> StateSG
        {
            get { return states; }
            set { states = value; }
        }

        public bool End
        {
            get { return end; }
            set { end = value; }
        }

        public State(Stack<State> states) => StateSG = states;

        public bool RequestEnd => End;

        virtual public void Update()
        {

        }
    }
}
