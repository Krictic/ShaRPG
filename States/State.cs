namespace ShaRPG.States
{
    internal class State
    {
        protected Stack<State> states { get; set; }
        protected bool end { get; set; } = false;

        public Stack<State> GetStateSG()
        { return states; }

        public void SetStateSG(Stack<State> value)
        { states = value; }

        public bool GetEnd()
        { return end; }

        public void SetEnd(bool value)
        { end = value; }

        public State(Stack<State> states) => SetStateSG(states);

        public bool RequestEnd => GetEnd();

        virtual public void Update()
        {

        }
    }
}
