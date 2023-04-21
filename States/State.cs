using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaRPG.States
{
    internal class State
    {
        protected Stack<State> states;
        protected bool end = false;
        public State(Stack<State> states) 
        {
            this.states = states;
        }

        public bool RequestEnd()
        {
            return this.end;
        }

        virtual public void Update()
        {

        }
    }
}
